using System;
using System.Collections.Generic;

#nullable disable

namespace backSisInvestigacion.Models
{
    public partial class TrabInvestigacion
    {
        public TrabInvestigacion()
        {
            RegistroInvestigacions = new HashSet<RegistroInvestigacion>();
        }

        public long IdtrabInvestigacion { get; set; }
        public long Idusuario { get; set; }
        public long Idasesor { get; set; }
        public int IdtipoInv { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string UrlInv { get; set; }
        public int Etapa { get; set; }

        public virtual Usuario IdasesorNavigation { get; set; }
        public virtual TipoInvestigacion IdtipoInvNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<RegistroInvestigacion> RegistroInvestigacions { get; set; }
    }
}
