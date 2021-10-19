using backSisInvestigacion.Models;
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
    public class facultadController : ControllerBase
    {
        private IFacultadService _facultad;
        public facultadController(IFacultadService facultad)
        {
            this._facultad = facultad;
        }


        [HttpPost]
        public IActionResult add(facultadEscuelaRequest model)
        {
            Response respuesta = new Response();
            try
            {
                _facultad.Add(model);
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
