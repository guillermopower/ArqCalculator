using System;

namespace ARQCALC.Entidades
{
    public class CalculoDeMaterialesResult
    {
        public int IdSubTipoCalculo { get; set; }
        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; }
        public decimal CantidadMaterial { get; set; }
        public string Abreviatura { get; set; }
    }
}
