using ARQCALC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARQCALC.DAL
{
    public interface ICalculoDeMaterialesDAL
    {
        List<CalculoDeMaterialesResult> GetMatrizCalculo(int IdSubTipoCalculo);
    }
}
