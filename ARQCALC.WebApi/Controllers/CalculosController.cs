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
        public string CalcularResistenciaTermica([FromBody]List<Item> ListaItems, bool EsMuro = true)
        {
            return _CalculosBusiness.CalcularResistenciaTermica(ListaItems, EsMuro);
        }

        //[ActionName("calcular-transmitancia")]
        [System.Web.Http.Route("api/calcular-transmitancia")]
        [HttpGet]
        public string CalcularTransmitancia(float Resistencia)
        {
            return _CalculosBusiness.CalcularTransmitancia(Resistencia);
        }

        [System.Web.Http.Route("api/calcular-masa")]
        [System.Web.Http.HttpPost]
        public string CalcularMasa([FromBody]List<Item> ListaItems)
        {
            return _CalculosBusiness.CalcularMasa(ListaItems);
        }

        //[ActionName("calcular-k-max-admisible")]
        [System.Web.Http.Route("api/calcular-k-max-admisible")]
        [HttpGet]
        public string CalcularKMaxAdmisible(float MasaMuro, string orientacion = null, string zona = "IIIb", bool EsCubierta = false)
        {
            return _CalculosBusiness.CalcularKMaxAdmisible(MasaMuro, orientacion, zona, EsCubierta);
        }
    }
}
