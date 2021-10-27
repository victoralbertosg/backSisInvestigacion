using backSisInvestigacion.Models;
using backSisInvestigacion.Models.Request;
using backSisInvestigacion.Models.Response;
using backSisInvestigacion.tools;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        bddSisInvestigacionContext db1;
        public UsuarioController(bddSisInvestigacionContext db1)
        {
            this.db1 = db1;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Response oResponse = new Response();
            try
            {
               // using(bddSisInvestigacionContext db = new bddSisInvestigacionContext())
                
                
                //{
                    //var lst = db.Usuarios.OrderByDescending(d=>d.Idusuario).ToList();
                    var lst =
                     from usuario in db1.Usuarios
                    join persona in db1.Personas on usuario.Idpersona equals persona.Idpersona     
                    select new {  Idpersona = persona.Idpersona, Idusuario = usuario.Idusuario, Nombre=persona.Nombre, Apellido=persona.Apellido, Rol=usuario.Rol };

                    //var lst = (from u in db.Usuarios
                    //        select u);
                   // IQueryable<Usuario> lst = db1.Usuarios.Select(c => c);
                 
                    oResponse.Exito = 1;
                    oResponse.Data = lst;
                //}
            }
            catch (Exception ex)
            {
                oResponse.Mensaje = ex.Message;
            }
            return Ok(oResponse);
        }
        [HttpGet("/usuario/{rol}")]
        public IActionResult GetbyRol(long rol)
        {
            Response oResponse = new Response();
            try
            {
                // using(bddSisInvestigacionContext db = new bddSisInvestigacionContext())


                //{
                //var lst = db.Usuarios.OrderByDescending(d=>d.Idusuario).ToList();
                var lst =
                 from usuario in db1.Usuarios
                 join persona in db1.Personas on usuario.Idpersona equals persona.Idpersona
                 where usuario.Rol==rol
                 select new { Idpersona = persona.Idpersona, Idusuario = usuario.Idusuario, Nombre = persona.Nombre, Apellido = persona.Apellido, Rol = usuario.Rol };
              
                //var lst = (from u in db.Usuarios
                //        select u);
                // IQueryable<Usuario> lst = db1.Usuarios.Select(c => c);

                oResponse.Exito = 1;
                oResponse.Data = lst;
                //}
            }
            catch (Exception ex)
            {
                oResponse.Mensaje = ex.Message;
            }
            return Ok(oResponse);
        }

        [HttpPost]
        public IActionResult Add(UsuarioRequest oModel)
        {
            Response oResponse = new Response();
            try
            {
                using (bddSisInvestigacionContext db = new bddSisInvestigacionContext())
                {
                    Usuario oUsuario = new Usuario();                   
                    oUsuario.Idpersona = oModel.Idpersona;
                    oUsuario.Idespecialidad = oModel.Idespecialidad;
                    oUsuario.Nivel = oModel.Nivel;
                    oUsuario.Password = Encript.GetSHA256(oModel.Password);
                    oUsuario.Rol = oModel.Rol;
                    db.Usuarios.Add(oUsuario);
                    db.SaveChanges();
                    oResponse.Exito = 1;                  
                }
            }
            catch (Exception ex)
            {
                oResponse.Mensaje = ex.Message;
            }
            return Ok(oResponse);

        }

        [HttpPut]
        public IActionResult Edit(UsuarioRequest oModel)
        {
            Response oResponse = new Response();
            try
            {
                using (bddSisInvestigacionContext db = new bddSisInvestigacionContext())
                {
                    Usuario oUsuario = db.Usuarios.Find(oModel.Idusuario);
                    oUsuario.Idpersona = oModel.Idpersona;
                    oUsuario.Idespecialidad = oModel.Idespecialidad;
                    oUsuario.Nivel = oModel.Nivel;
                    oUsuario.Password = oModel.Password;
                    oUsuario.Rol = oModel.Rol;
                    db.Entry(oUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oResponse.Exito = 1;
                    
                }
            }
            catch (Exception ex)
            {
                oResponse.Mensaje = ex.Message;
            }
            return Ok(oResponse);

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            Response oResponse = new Response();
            try
            {
                using (bddSisInvestigacionContext db = new bddSisInvestigacionContext())
                {
                    var lst = db.Usuarios.Select(c => c);
                    
                    Usuario oUsuario = db.Usuarios.Find(Id);                   
                    db.Remove(oUsuario);                   
                    db.SaveChanges();
                    oResponse.Exito = 1;

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

