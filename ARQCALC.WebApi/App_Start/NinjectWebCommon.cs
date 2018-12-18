[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ARQCALC.WebApi.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ARQCALC.WebApi.NinjectWebCommon), "Stop")]

namespace ARQCALC.WebApi
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using System.Configuration;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.WebApi;
    using System.Web.Http;
    using ARQCALC.Business;
    using ARQCALC.Entidades;
    using ARQCALC.DAL;
    using System.Collections.Generic;
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
                // GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
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
        /// Starts the application
        /// </summary>
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IConnectionBase>().To<ConnectionBase>();
            kernel.Bind<IMaterialDAL>().To<MaterialDAL>();
            kernel.Bind<IMaterialBusiness>().To<MaterialBusiness>();
            kernel.Bind<IZonaBioAmbientalDAL>().To<ZonaBioAmbientalDAL>();
            kernel.Bind<IZonaBioAmbientalBusiness>().To<ZonaBioAmbientalBusiness>();
           
        }
    }
}