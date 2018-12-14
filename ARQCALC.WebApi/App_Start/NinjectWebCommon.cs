[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ARQCALC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ARQCALC.App_Start.NinjectWebCommon), "Stop")]

namespace ARQCALC.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using System.Configuration;
    using IDomAux.Core;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.WebApi;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.Configuration;
    // using ARQCALC.Models;
    using ARQCALC.Entidades;
    using System.Collections.Generic;
    using IDomAux.Data;
    using System.Data.Entity;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        private static StandardKernel _kernel;

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {   
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static T GetInstance<T>()
        {
            return _kernel.Get<T>();
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                _kernel = kernel;
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ARQCALCEntities>().To<ARQCALCEntities>().InRequestScope().WithConstructorArgument("conn", ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            kernel.Bind<IVisitaRepository>().To<VisitaRepository>();
            kernel.Bind<IPrestadorRepository>().To<PrestadorRepository>();
            kernel.Bind<IPrestadorPacienteRepository>().To<PrestadorPacienteRepository>();
            kernel.Bind<IPacienteRepository>().To<PacienteRepository>();
            kernel.Bind<IVisitaObsRepository>().To<VisitaObsRepository>();
            kernel.Bind<IVisitaPrestacionRepository>().To<VisitaPrestacionRepository>();

            var config = new AutoMapper.MapperConfiguration(ConfigureMapper);
            kernel.Bind<IConfigurationProvider>().ToConstant<MapperConfiguration>(config);
            kernel.Bind<IMapper>().To<Mapper>();
            kernel.Bind<IDomAuxCore>().To<DomAuxCore>();
        }

        private static void ConfigureMapper(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Patient, pacientes>()
                    .ForMember(t => t.domicilio_geo_lat, opt => opt.MapFrom(i => decimal.Parse(i.geo != null ? i.geo.latitud : "0")))
                    .ForMember(t => t.domicilio_geo_long, opt => opt.MapFrom(i => decimal.Parse(i.geo != null ? i.geo.longitud : "0")));

            expression.CreateMap<prestadores, Prestador>()
                .ForMember(t => t.id, opt => opt.MapFrom(i => i.prestador_id))
                .ForMember(t => t.email, opt => opt.MapFrom(i => i.email))
                .ForMember(t => t.name, opt => opt.MapFrom(i => i.nombre))
                .ForMember(t => t.prestacion, opt => opt.MapFrom(i => i.tipo))
                .ForMember(t => t.alias, opt => opt.MapFrom(i => i.alias));

            expression.CreateMap<prestador_pacientes, Prestacion>()
                .ForMember(t => t.frecuencia, opt => opt.MapFrom(i => i.periodicidad))
                .ForMember(t => t.nombre, opt => opt.MapFrom(i => i.prestacion));

            expression.CreateMap<pacientes, Patient>()
                .ForMember(t => t.id, opt => opt.MapFrom(i => i.paciente_id))
                .ForMember(t => t.lastname, opt => opt.MapFrom(i => i.apellido))
                .ForMember(t => t.name, opt => opt.MapFrom(i => i.nombre))
                .ForMember(t => t.phone, opt => opt.MapFrom(i => i.telefono))
                .ForMember(t => t.dir, opt => opt.MapFrom(i => i.domicilio))
                .ForMember(t => t.prestaciones, opt => opt.MapFrom<IList<prestador_pacientes>>(i => i.prestaciones))
                .ForMember(t => t.Visitas, opt => opt.MapFrom<IList<prestador_visitas>>(i => i.visitas))
                .ForMember(t => t.geo, opt => opt.MapFrom(i => new Location { latitud = i.domicilio_geo_lat.ToString(), longitud = i.domicilio_geo_long.ToString() }));

            expression.CreateMap<Visit, prestador_visitas>()
                .ForMember(t => t.geo_lat, opt => opt.MapFrom(i => decimal.Parse(i.geo != null ? i.geo.latitud : "0")))
                .ForMember(t => t.fecha, opt => opt.MapFrom(i => i.created_at))
                .ForMember(t => t.visita_id, opt => opt.MapFrom(i => i.id))
                .ForMember(t => t.prestador_id, opt => opt.MapFrom(i => i.id_prestador))
                .ForMember(t => t.geo_long, opt => opt.MapFrom(i => decimal.Parse(i.geo != null ? i.geo.longitud : "0")));

            expression.CreateMap<VisitObs, prestador_visitas_obs>()
                .ForMember(t => t.fecha, opt => opt.MapFrom(i => DateTime.Now))
                .ForMember(t => t.visita_id, opt => opt.MapFrom(i => i.visit_id))
                .ForMember(t => t.observacion, opt => opt.MapFrom(i => i.detail));

            expression.CreateMap<AddVisit, prestador_visitas>()
                .ForMember(t => t.caso_id, opt => opt.MapFrom(i => i.caso_id))
                .ForMember(t => t.fecha, opt => opt.MapFrom(i => i.created_at))
                .ForMember(t => t.geo_lat, opt => opt.MapFrom(i => i.geo.latitud))
                .ForMember(t => t.geo_long, opt => opt.MapFrom(i => i.geo.longitud))
                .ForMember(t => t.prestaciones, opt => opt.Ignore())
                .ForMember(t => t.prestador_id, opt => opt.MapFrom(i => i.id_prestador))
                .ForMember(t => t.visita_id, opt => opt.MapFrom(i => i.id))
                .ForMember(t => t.dir, opt => opt.MapFrom(i => i.dir))
                .ForMember(t => t.paciente_id, opt => opt.MapFrom(i => i.id_paciente));

            expression.CreateMap<prestador_visitas_obs, VisitObs>()
                .ForMember(t => t.created_at, opt => opt.MapFrom(i => i.fecha))
                .ForMember(t => t.detail, opt => opt.MapFrom(i => i.observacion))
                .ForMember(t => t.id, opt => opt.MapFrom(i => i.visita_ln))
                .ForMember(t => t.visit_id, opt => opt.MapFrom(i => i.visita_id));

            expression.CreateMap<VisitaPrestacion, visita_prestacion>()
                .ForMember(t => t.id, opt => opt.MapFrom(i => i.id))
                .ForMember(t => t.visita_id, opt => opt.MapFrom(i => i.visita_id))
                .ForMember(t => t.prestacion_id, opt => opt.MapFrom(i => i.prestacion_id))
                .ForMember(t => t.prestacion_nombre, opt => opt.MapFrom(i => i.prestacion_nombre));

            expression.CreateMap<prestador_visitas, Visit>()
                .ForMember(t => t.id, opt => opt.MapFrom(i => i.visita_id))
                .ForMember(t => t.id_paciente, opt => opt.MapFrom(i => i.caso_id))
                .ForMember(t => t.id_prestador, opt => opt.MapFrom(i => i.prestador_id))
                .ForMember(t => t.created_at, opt => opt.MapFrom(i => i.fecha))
                .ForMember(t => t.update_at, opt => opt.MapFrom(i => i.fecha))
                .ForMember(t => t.geo, opt => opt.MapFrom(i => new Location { latitud = i.geo_lat.ToString(), longitud = i.geo_long.ToString() }));
        }
    }
}
