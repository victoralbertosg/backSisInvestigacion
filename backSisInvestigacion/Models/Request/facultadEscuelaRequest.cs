using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Models.Request
{
    public class facultadEscuelaRequest
    {
        public string descripcion { get; set; }
        public List<Especialidad> especialidades { get; set; }
        public facultadEscuelaRequest()
        {
            this.especialidades = new List<Especialidad>();
        }

        public class Especialidad
        {
            public string descripcion { get; set; }

        }
    }
}
