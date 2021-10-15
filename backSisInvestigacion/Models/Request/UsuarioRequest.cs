using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Models.Request
{
    public class UsuarioRequest
    {
        public long Idusuario { get; set; }
        public long Idpersona { get; set; }
        public int Idespecialidad { get; set; }
        public int Rol { get; set; }
        public string Password { get; set; }
        public int? Nivel { get; set; }
    }
}
