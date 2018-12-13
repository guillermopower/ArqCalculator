using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Http.Cors;
//using Microsoft.AspNet.WebApi.Cors;

namespace ARQCALC.WebApi.Tests.Controllers
{
    //[AllowAnonymous]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    //public class CargaRegistroVentasCacsController : ApiController
    //{
    //    private readonly IBLCACs _bLCACs;
    //    private readonly IBLRegistroVentas _bLRegistroVentas;

    //    public CargaRegistroVentasCacsController(IBLCACs bLCACs, IBLRegistroVentas bLRegistroVentas)
    //    {
    //        _bLCACs = bLCACs;
    //        _bLRegistroVentas = bLRegistroVentas;
    //    }

    //    [Route("api/cargaregistroventas/transacciones-prepago-cacs/previsualizar")]
    //    [HttpPost]
    //    public IEnumerable<BECacsResumen> Previsualizar(BEFechas oBEFechas)
    //    {
    //        oBEFechas.FechaDesde = new DateTime(oBEFechas.FechaDesde.Year, oBEFechas.FechaDesde.Month, oBEFechas.FechaDesde.Day, 0, 0, 0);
    //        oBEFechas.FechaHasta = new DateTime(oBEFechas.FechaHasta.Year, oBEFechas.FechaHasta.Month, oBEFechas.FechaHasta.Day, 23, 59, 59);

    //        return _bLCACs.PrevisualizarTransaccionesPrepago(oBEFechas);
    //    }

    //    [Route("api/cargaregistroventas/transacciones-prepago-cacs/obtener")]
    //    [HttpPost]
    //    public IEnumerable<BECacs> Obtener(BEFechas oBEFechas)
    //    {
    //        oBEFechas.FechaDesde = new DateTime(oBEFechas.FechaDesde.Year, oBEFechas.FechaDesde.Month, oBEFechas.FechaDesde.Day, 0, 0, 0);
    //        oBEFechas.FechaHasta = new DateTime(oBEFechas.FechaHasta.Year, oBEFechas.FechaHasta.Month, oBEFechas.FechaHasta.Day, 23, 59, 59);

    //        return _bLCACs.ObtenerTransaccionesPrepago(oBEFechas.FechaDesde, oBEFechas.FechaHasta);
    //    }

    //    [Route("api/cargaregistroventas/transacciones-prepago-cacs/aprobar")]
    //    [HttpPost]
    //    public int Aprobar([FromBody]BECacsInput oBECacsInput)
    //    {
    //        oBECacsInput.FechaDesde = new DateTime(oBECacsInput.FechaDesde.Year, oBECacsInput.FechaDesde.Month, oBECacsInput.FechaDesde.Day, 0, 0, 0);
    //        oBECacsInput.FechaHasta = new DateTime(oBECacsInput.FechaHasta.Year, oBECacsInput.FechaHasta.Month, oBECacsInput.FechaHasta.Day, 23, 59, 59);

    //        return _bLRegistroVentas.AprobarRegistroVentasCacs(oBECacsInput.ListaCacs, oBECacsInput.UserName, oBECacsInput.FechaDesde, oBECacsInput.FechaHasta);
    //    }

    //}
}