using System;
using System.Collections.Generic;

#nullable disable

namespace backSisInvestigacion.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            RegistroInvestigacions = new HashSet<RegistroInvestigacion>();
            TrabInvestigacionIdasesorNavigations = new HashSet<TrabInvestigacion>();
            TrabInvestigacionIdusuarioNavigations = new HashSet<TrabInvestigacion>();
        }

        public long Idusuario { get; set; }
        public long Idpersona { get; set; }
        public int Idespecialidad { get; set; }
        public int Rol { get; set; }
        public string Password { get; set; }
        public int? Nivel { get; set; }

        public virtual Especialidad IdespecialidadNavigation { get; set; }
        public virtual Persona IdpersonaNavigation { get; set; }
        public virtual ICollection<RegistroInvestigacion> RegistroInvestigacions { get; set; }
        public virtual ICollection<TrabInvestigacion> TrabInvestigacionIdasesorNavigations { get; set; }
        public virtual ICollection<TrabInvestigacion> TrabInvestigacionIdusuarioNavigations { get; set; }
    }
}
