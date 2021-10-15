using System;
using System.Collections.Generic;

#nullable disable

namespace backSisInvestigacion.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public long Idpersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
