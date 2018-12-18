using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARQCALC.Entidades;

namespace ARQCALC.Business
{
    public interface IZonaBioAmbientalBusiness
    {
        List<ARQCALC.Entidades.ZonaBioAmbiental> GetZonaBioAmbientales(int? IdZonaBioAmbiental, string NombreZonaBioAmbiental);
    }
}
