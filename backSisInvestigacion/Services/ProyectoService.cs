using backSisInvestigacion.Models;
using backSisInvestigacion.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Services
{
    public class ProyectoService : IProyectoService
    {

        public bddSisInvestigacionContext bd;

        public ProyectoService(bddSisInvestigacionContext bd)
        {
            this.bd = bd;
        }

        public object getAllByUser(int user)
        {

               var lst = from inv in bd.TrabInvestigacions
                      join tipoInv in bd.TipoInvestigacions on inv.IdtipoInv equals tipoInv.IdtipoInv
                      join usuario in (from usu in bd.Usuarios
                                       join persona in bd.Personas on usu.Idpersona equals persona.Idpersona
                                       select new { Idusuario = usu.Idusuario, alumno = persona.Nombre +" " + persona.Apellido }) on inv.Idusuario equals usuario.Idusuario
                      join asesor in (from ase in bd.Usuarios
                                       join persona in bd.Personas on ase.Idpersona equals persona.Idpersona
                                       select new { Idasesor = ase.Idusuario, asesor = persona.Nombre + " " + persona.Apellido }) on inv.Idasesor equals asesor.Idasesor
                      where  usuario.Idusuario==user
                      select new {idtrab_investigacion=inv.IdtrabInvestigacion,titulo = inv.Titulo, Descripcion=tipoInv.Descripcion, alumno=usuario.alumno, asesor.asesor, url=inv.UrlInv, fecha=inv.Fecha, etapa=inv.Etapa};
              return lst;
                 
         }
        public  object getAllByAsesor (int user)
        {
            var lst = from inv in bd.TrabInvestigacions
                      join tipoInv in bd.TipoInvestigacions on inv.IdtipoInv equals tipoInv.IdtipoInv
                      join usuario in (from usu in bd.Usuarios
                                       join persona in bd.Personas on usu.Idpersona equals persona.Idpersona
                                       select new { Idusuario = usu.Idusuario, alumno = persona.Nombre + " " + persona.Apellido }) on inv.Idusuario equals usuario.Idusuario
                      join asesor in (from ase in bd.Usuarios
                                      join persona in bd.Personas on ase.Idpersona equals persona.Idpersona
                                      select new { Idasesor = ase.Idusuario, asesor = persona.Nombre + " " + persona.Apellido }) on inv.Idasesor equals asesor.Idasesor
                      where inv.Idasesor == user
                      select new { idtrab_investigacion = inv.IdtrabInvestigacion, titulo = inv.Titulo, Descripcion = tipoInv.Descripcion, alumno = usuario.alumno, asesor.asesor, url = inv.UrlInv, fecha = inv.Fecha, etapa = inv.Etapa };
            return lst;
        }


        public object getAll()
        {

            var lst = from inv in bd.TrabInvestigacions
                      join tipoInv in bd.TipoInvestigacions on inv.IdtipoInv equals tipoInv.IdtipoInv
                      join usuario in (from usu in bd.Usuarios
                                       join persona in bd.Personas on usu.Idpersona equals persona.Idpersona
                                       select new { Idusuario = usu.Idusuario, alumno = persona.Nombre + " " + persona.Apellido }) on inv.Idusuario equals usuario.Idusuario
                      join asesor in (from ase in bd.Usuarios
                                      join persona in bd.Personas on ase.Idpersona equals persona.Idpersona
                                      select new { Idasesor = ase.Idusuario, asesor = persona.Nombre + " " + persona.Apellido }) on inv.Idasesor equals asesor.Idasesor                     
                      select new { idtrab_investigacion = inv.IdtrabInvestigacion, titulo = inv.Titulo, Descripcion = tipoInv.Descripcion, alumno = usuario.alumno, asesor.asesor, url = inv.UrlInv, fecha = inv.Fecha, etapa = inv.Etapa };
            return lst;

        }


        public void add(TrabInvestigacionRequest proyectoRequest){
            using (bddSisInvestigacionContext db1 = new bddSisInvestigacionContext())
            {
                using (var transaction = db1.Database.BeginTransaction())
                {
                    try
                    {
                        TrabInvestigacion oproyecto = new TrabInvestigacion();
                        oproyecto.IdtrabInvestigacion = proyectoRequest.IdtrabInvestigacion;
                        oproyecto.Titulo = proyectoRequest.Titulo;
                        oproyecto.Idusuario = proyectoRequest.Idusuario;
                        oproyecto.Idasesor = proyectoRequest.Idasesor;
                        oproyecto.Etapa = proyectoRequest.Etapa;
                        oproyecto.Fecha = proyectoRequest.Fecha;
                        oproyecto.IdtipoInv = proyectoRequest.IdtipoInv;
                        oproyecto.UrlInv = proyectoRequest.UrlInv;
                        db1.TrabInvestigacions.Add(oproyecto);
                        db1.SaveChanges();
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        
                        transaction.Rollback();
                    }
                }
            }
        }

    }
}
