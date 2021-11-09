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
    public class ProyectoController : ControllerBase
    {

        public Response oResponse = new Response();
        private IProyectoService proyecto;

        public ProyectoController(IProyectoService proyecto)
        {
            this.proyecto = proyecto;
        }


        [HttpGet]
        public IActionResult getAll()
        {
            var lst = proyecto.getAll();

            oResponse.Exito = 1;
            oResponse.Data = lst;

            return Ok(this.oResponse);
        }

        [HttpGet("/api/proyecto/user/{id}")]
        public IActionResult getAll(int id)
        {
            var lst = proyecto.getAllByUser(id);

            oResponse.Exito = 1;
            oResponse.Data = lst;

            return Ok(this.oResponse);
        }

        [HttpGet("/api/proyecto/trabinv/{id}")]
        public IActionResult getByTrabInv(int id)
        {
            var lst = proyecto.getByTrabInv(id);
            oResponse.Exito = 1;
            oResponse.Data = lst;
            return Ok(this.oResponse);
        }


        [HttpGet("/api/proyecto/asesor/{id}")]
        public IActionResult getAllByAsesor(int id)
        {
            var lst = proyecto.getAllByAsesor(id);

            oResponse.Exito = 1;
            oResponse.Data = lst;

            return Ok(this.oResponse);
        }


        [HttpPost]
        public IActionResult add(TrabInvestigacionRequest oproyecto)
        {
            Response respuesta = new Response();
            try
            {
                proyecto.add(oproyecto);
                respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);        

        }
        [HttpPut]
        public IActionResult edit(TrabInvestigacionRequest oproyecto)
        {
            Response respuesta = new Response();
            try
            {
                proyecto.edit(oproyecto);
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
