namespace ARQCALC.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubTiposCalculos_Materiales
    {
        public int IdSubTipoCalculo { get; set; }
        public int IdMaterial { get; set; }
        public Nullable<decimal> CantidadMaterial { get; set; }
    
        public virtual Material Materiales { get; set; }
        public virtual SubTiposCalculos SubTiposCalculos { get; set; }
    }
}
