using backSisInvestigacion.Models;
using backSisInvestigacion.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Services
{
    public class RegInvService : IRegInvService
    {
        public void add(RegInvRequest model)
        {
            using (bddSisInvestigacionContext db = new bddSisInvestigacionContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        RegistroInvestigacion regInv = new RegistroInvestigacion();
                        regInv.IdregInv = model.IdregInv;
                        regInv.IdtrabInvestigacion = model.IdtrabInvestigacion;
                        
                        regInv.Etapa = model.Etapa;
                        regInv.Idusuario = model.Idusuario;
                        regInv.Fecha = model.Fecha;                        
                        regInv.Observaciones = model.Observaciones;
                        db.RegistroInvestigacions.Add(regInv);
                        db.SaveChanges();
                        
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("dasd",e) ;
                        transaction.Rollback();
                    }
                }
            }

        }
    }
}

