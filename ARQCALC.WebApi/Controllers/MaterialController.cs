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
    public class MaterialController : ApiController
    {
        private readonly MaterialBusiness _MaterialBusiness;

        public MaterialController(MaterialBusiness oMaterialBusiness)
        {
            _MaterialBusiness = oMaterialBusiness;
        }

        [ActionName("obtener-materiales")]
        [HttpGet]
        public IEnumerable<Material>ObtenerTodos()
        {
            return _MaterialBusiness.GetMateriales(null,null);
        }

        [ActionName("obtener-materiales-by-id")]
        [HttpGet]
        public IEnumerable<Material> Get(int? id, string nombre)
        {
            return _MaterialBusiness.GetMateriales(id,nombre);
        }


    }
}
