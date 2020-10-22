using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;
using ARQCALC.Entidades;
using ARQCALC.Business;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using System.Web.Http.Cors;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace ARQCALC.WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CalculosController : ApiController
    {
        private readonly CalculosBusiness _CalculosBusiness;

        public CalculosController(CalculosBusiness oCalculosBusiness)
        {
            _CalculosBusiness = oCalculosBusiness;
        }

        [System.Web.Http.Route("api/calcular-resistencia-termica")]
        [System.Web.Http.HttpPost]
        public string CalcularResistenciaTermica([FromBody]ParamsCalcularResistenciaTermica parametros)
        {
            return _CalculosBusiness.CalcularResistenciaTermica(parametros.ListaItems, parametros.EsMuro);
        }

        //[ActionName("calcular-transmitancia")]
        [System.Web.Http.Route("api/calcular-transmitancia")]
        [HttpPost]
        public string CalcularTransmitancia([FromBody]ParamsCalcularTansmitancia parametros)
        {
            return _CalculosBusiness.CalcularTransmitancia(parametros.ResistenciaTermica);
        }

        [System.Web.Http.Route("api/calcular-masa")]
        [System.Web.Http.HttpPost]
        public string CalcularMasa([FromBody]ParamsCalcularMasa parametros)
        {
            return _CalculosBusiness.CalcularMasa(parametros.ListaItems);
        }

        [System.Web.Http.Route("api/calcular-k-max-admisible")]
        [HttpPost]
        //public string CalcularKMaxAdmisible(float MasaMuro, string orientacion = null, string zona = "IIIb", bool EsCubierta = false)
        public string CalcularKMaxAdmisible([FromBody]ParamsCalcularKMaxAdmisible parametros)
        {
            return _CalculosBusiness.CalcularKMaxAdmisible(parametros.MasaMuro, parametros.orientacion, parametros.zona, (bool)parametros.EsCubierta);
        }

        [System.Web.Http.Route("api/calcular-cantidad-materiales/{IdSubTipoCalculo}/")]
        [HttpGet]
        public List<CalculoDeMaterialesResult> CalcularCantidadMateriales(int IdSubTipoCalculo)
        {
            return _CalculosBusiness.GetMatrizCalculo(IdSubTipoCalculo);
        }
    }
   
    public class ParamsCalcularResistenciaTermica
    {
        public List<Item> ListaItems { get; set; }
        public bool EsMuro { get; set; }
    }
    public class ParamsCalcularTansmitancia
    {
        public float ResistenciaTermica { get; set; }
    }
    public class ParamsCalcularMasa
    {
        public List<Item> ListaItems { get; set; }
    }
    public class ParamsCalcularKMaxAdmisible
    {
        public float MasaMuro { get; set; }
        public string orientacion { get; set; }
       
        private string _zona;

        public string zona
        {
            get { return _zona; }
            set { _zona = (value ?? "IIIb"); }
        }

        private bool? _EsCubierta;

        public bool? EsCubierta
        {
            get { return _EsCubierta; }
            set { _EsCubierta = (value??false); }
        }

    }
}
