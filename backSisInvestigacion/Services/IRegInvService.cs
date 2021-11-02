using backSisInvestigacion.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Services
{
    public interface IRegInvService
    {
       // public object getAll(int user);
        public void add(RegInvRequest model);

    }
}
