using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARQCALC.Entidades
{
    public class Material
    {
        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; }
        public decimal? PesoEspecificoDesde { get; set; }
        public decimal? PesoEspecificoHasta { get; set; }
        public decimal? ConductividadPractica { get; set; }
        public int? IdUnidadMedida { get; set; }
    }
}