using backSisInvestigacion.Models;
using backSisInvestigacion.Models.Response;
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
    public class Tipo_InvController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            Response oResponse = new Response();
            try
            {
                using (bddSisInvestigacionContext db = new bddSisInvestigacionContext())


                {
                    var lst = db.TipoInvestigacions.OrderByDescending(d => d.IdtipoInv).ToList();
                    oResponse.Exito = 1;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Mensaje = ex.Message;
            }
            return Ok(oResponse);
        }
    }
}

