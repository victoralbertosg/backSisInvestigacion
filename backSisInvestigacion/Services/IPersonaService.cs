using backSisInvestigacion.Models;
using backSisInvestigacion.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Services
{
    interface IPersonaService
    {
        public Persona GetById(int id);
     
    }
}
