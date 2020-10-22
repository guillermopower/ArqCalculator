using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARQCALC.Entidades
{
    public class ZonaBioAmbiental
    {
        public int IdZona { get; set; }
        public string NombreZona { get; set; }
        public string OrientacionExterna { get; set; }
        public string IndiceExterno { get; set; }
        public string IndiceCubierta { get; set; }
        public string Observaciones { get; set; }
        public string Descripcion { get; set; }
    }
}