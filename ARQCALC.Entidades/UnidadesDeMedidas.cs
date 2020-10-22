using System;
using System.Collections.Generic;

namespace ARQCALC.Entidades
{
    public partial class UnidadesDeMedidas
    {
        public UnidadesDeMedidas()
        {
            this.Materiales = new HashSet<Material>();
        }
    
        public int IdUnidadMedida { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public string Tipo { get; set; }
    
        public virtual ICollection<Material> Materiales { get; set; }
    }
}
