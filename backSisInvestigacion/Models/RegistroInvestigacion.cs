using System;
using System.Collections.Generic;

#nullable disable

namespace backSisInvestigacion.Models
{
    public partial class RegistroInvestigacion
    {
        public int IdregInv { get; set; }
        public long IdtrabInvestigacion { get; set; }
        public int Etapa { get; set; }
        public long Idusuario { get; set; }
        public DateTime? Fecha { get; set; }       
        public string Observaciones { get; set; }

        public virtual TrabInvestigacion IdtrabInvestigacionNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
