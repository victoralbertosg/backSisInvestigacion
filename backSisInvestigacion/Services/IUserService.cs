using backSisInvestigacion.Models.Request;
using backSisInvestigacion.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Services
{
   public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
