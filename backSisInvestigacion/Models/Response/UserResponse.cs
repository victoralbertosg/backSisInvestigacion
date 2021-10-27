using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Models.Response
{
    public class UserResponse
    {
        public long idusuario { get; set; }
        public string Token { get; set; }
        public int rol { get; set; }
    }
}
