using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARQCALC.Entidades;

namespace ARQCALC.Business.CalculoMateriales
{
    public interface ISubTiposCalculosBusiness
    {
        List<Entidades.SubTiposCalculos> Get(int? IdSubTipoCalculo);
        List<Entidades.ResultCalculoMateriales> CalcularMateriales(int? IdSubTipoCalculo, decimal SuperficieVolumen);
    }
}
