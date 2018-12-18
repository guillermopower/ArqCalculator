using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
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
    public class ZonaBioAmbientalController : ApiController
    {
        private readonly ZonaBioAmbientalBusiness _ZonaBioAmbientalBusiness;

        public ZonaBioAmbientalController(ZonaBioAmbientalBusiness oZonaBioAmbientalBusiness)
        {
            _ZonaBioAmbientalBusiness = oZonaBioAmbientalBusiness;
        }

        [ActionName("obtener-zonas")]
        [HttpGet]
        public IEnumerable<ZonaBioAmbiental>ObtenerTodos()
        {
            return _ZonaBioAmbientalBusiness.GetZonaBioAmbientales(null,null);
        }

        [ActionName("obtener-zona-by-id")]
        [HttpGet]
        public IEnumerable<ZonaBioAmbiental> Get(int? id, string nombre)
        {
            return _ZonaBioAmbientalBusiness.GetZonaBioAmbientales(id,nombre);
        }


    }
}
