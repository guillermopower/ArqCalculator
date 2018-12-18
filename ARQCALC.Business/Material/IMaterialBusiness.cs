using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARQCALC.Entidades;

namespace ARQCALC.Business
{
    public interface IMaterialBusiness
    {
        List<ARQCALC.Entidades.Material> GetMateriales(int? IdMaterial, string NombreMaterial);
    }
}
