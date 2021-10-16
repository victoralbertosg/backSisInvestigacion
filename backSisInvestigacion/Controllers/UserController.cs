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
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model) {

            Response response = new Response();
            var userresponse = _userService.Auth(model);
            if (userresponse == null)
            {
                response.Exito = 0;
                response.Mensaje = "usuaio o clave incorrecto";
                return BadRequest(response);
            }
            response.Exito = 1;
            response.Data = userresponse;
            return Ok(response);
        }

    }
}
