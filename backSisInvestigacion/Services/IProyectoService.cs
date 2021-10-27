using backSisInvestigacion.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Services
{
    public interface IProyectoService
    {

      

        public object getAll(int user);
        public void add(TrabInvestigacionRequest proyectoRequest);


    }
}
