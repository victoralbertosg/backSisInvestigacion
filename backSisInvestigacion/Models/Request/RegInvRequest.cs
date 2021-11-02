using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Models.Request
{
    public class RegInvRequest
    {
        public int Idetapainv { get; set; }
        public long IdtrabInvestigacion { get; set; }
        public int Etapa { get; set; }
        public long Idusuario { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdtipoInv { get; set; }
        public string Observaciones { get; set; }
    }
}
