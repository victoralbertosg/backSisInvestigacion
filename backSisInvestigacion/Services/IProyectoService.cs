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

      

        public object getAllByUser(int user);
        public object getAllByAsesor(int user);
        public object getAll();
        public void add(TrabInvestigacionRequest proyectoRequest);
        public void edit(TrabInvestigacionRequest proyectoRequest);

        object getByTrabInv(int trabinv);



    }
}
