using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ARQCALC.Entidades;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using System.Web.Http.Cors;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using ARQCALC.Business.CalculoMateriales;

namespace ARQCALC.WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CalculoMaterialesController : ApiController
    {
        private readonly SubTiposCalculosBusiness _SubTiposCalculosBusiness;

        public CalculoMaterialesController(SubTiposCalculosBusiness oSubTiposCalculosBusiness)
        {
            _SubTiposCalculosBusiness = oSubTiposCalculosBusiness;
        }

        [System.Web.Http.Route("api/obtener-subtipos-calculos/{IdSubTipoCalculo}/")]
        [HttpGet]
        public IEnumerable<SubTiposCalculos>get(int? IdSubTipoCalculo)
        {
            return _SubTiposCalculosBusiness.Get(IdSubTipoCalculo);
        }

        [System.Web.Http.Route("api/calcular-materiales/{IdSubTipoCalculo}/{SuperficieVolumen}/")]
        [HttpGet]
        public IEnumerable<ResultCalculoMateriales> CalcularMateriales(int? IdSubTipoCalculo, decimal SuperficieVolumen)
        {
            return _SubTiposCalculosBusiness.CalcularMateriales(IdSubTipoCalculo, SuperficieVolumen);
        }
    }
}
