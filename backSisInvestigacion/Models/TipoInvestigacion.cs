using System;
using System.Collections.Generic;

#nullable disable

namespace backSisInvestigacion.Models
{
    public partial class TipoInvestigacion
    {
        public TipoInvestigacion()
        {
            TrabInvestigacions = new HashSet<TrabInvestigacion>();
        }

        public int IdtipoInv { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TrabInvestigacion> TrabInvestigacions { get; set; }
    }
}
