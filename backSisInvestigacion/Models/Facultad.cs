using System;
using System.Collections.Generic;

#nullable disable

namespace backSisInvestigacion.Models
{
    public partial class Facultad
    {
        public Facultad()
        {
            Especialidads = new HashSet<Especialidad>();
        }

        public int Idfacultad { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Especialidad> Especialidads { get; set; }
    }
}
