using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Models.Request
{
    public class TrabInvestigacionRequest
    {
        public long IdtrabInvestigacion { get; set; }
        public long Idusuario { get; set; }
        public long Idasesor { get; set; }
        public int IdtipoInv { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string UrlInv { get; set; }
        public int Etapa { get; set; }
    }
}
