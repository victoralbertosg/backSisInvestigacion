using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public long idusuario { get; set; }
        [Required]
        public string Password{ get; set; }
}
}
