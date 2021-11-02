using backSisInvestigacion.Models.Request;
using backSisInvestigacion.Models.Response;
using backSisInvestigacion.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegInvController : ControllerBase
    {
        private IRegInvService reginv;

        public RegInvController(IRegInvService reginv)
        {
            this.reginv = reginv;
        }


        

        [HttpPost]
        public IActionResult add(RegInvRequest oRegInv)
        {
            Response respuesta = new Response();
            try
            {
                reginv.add(oRegInv);
                respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
