using System;
using System.Collections.Generic;

#nullable disable

namespace backSisInvestigacion.Models
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Idespecialidad { get; set; }
        public int Idfacultad { get; set; }
        public string Descripcion { get; set; }

        public virtual Facultad IdfacultadNavigation { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
