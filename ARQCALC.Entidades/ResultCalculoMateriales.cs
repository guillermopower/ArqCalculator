using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARQCALC.Entidades
{
    public class ResultCalculoMateriales
    {
        public int IdSubTipoCalculo { get; set; }
        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; }
        public decimal CantidadMaterial { get; set; }
        public string UnidadMedida { get; set; }
    }
}
