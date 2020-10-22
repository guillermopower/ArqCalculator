using System;
using System.Collections.Generic;

namespace ARQCALC.Entidades
{
    public partial class SubTiposCalculos
    {
      
        public SubTiposCalculos()
        {
            this.SubTiposCalculos_Materiales = new HashSet<SubTiposCalculos_Materiales>();
        }
    
        public int IdSubTipoCalculo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Habilitada { get; set; }
        public Nullable<int> IdTipoCalculo { get; set; }
    
      
        public virtual ICollection<SubTiposCalculos_Materiales> SubTiposCalculos_Materiales { get; set; }
        public virtual TiposCalculos TiposCalculos { get; set; }
    }
}
