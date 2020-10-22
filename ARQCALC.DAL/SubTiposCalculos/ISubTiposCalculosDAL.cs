using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARQCALC.Entidades;

namespace ARQCALC.DAL.SubTiposCalculos
{
    public interface ISubTiposCalculosDAL
    {
        List<ARQCALC.Entidades.SubTiposCalculos> Get(int? IdSubTipoCalculo = null);
        List<ARQCALC.Entidades.ResultCalculoMateriales> CalcularMateriales(int? IdSubTipoCalculo = null, decimal? SuperficieVolumen = 1);
    }
}
