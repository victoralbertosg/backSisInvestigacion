using backSisInvestigacion.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Services
{
    public interface IFacultadService
    {
        public void Add(facultadEscuelaRequest model);

    }
}
