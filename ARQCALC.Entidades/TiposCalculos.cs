using System;
using System.Collections.Generic;

namespace ARQCALC.Entidades
{
    public partial class TiposCalculos
    {
        public TiposCalculos()
        {
            this.SubTiposCalculos = new HashSet<SubTiposCalculos>();
        }
    
        public int IdTipoCalculo { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<SubTiposCalculos> SubTiposCalculos { get; set; }
    }
}
