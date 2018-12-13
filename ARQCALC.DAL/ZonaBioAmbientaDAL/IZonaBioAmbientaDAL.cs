using ARQCALC.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARQCALC.DAL
{
    public interface IZonaBioAmbientalDAL
    {
        List<ZonaBioAmbiental> GetZonaBioAmbiental(int? IdZonza = null, string NombreZona = null);
    }
}