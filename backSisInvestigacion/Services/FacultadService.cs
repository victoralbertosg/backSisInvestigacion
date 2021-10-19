using backSisInvestigacion.Models;
using backSisInvestigacion.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Services
{
    public class FacultadService: IFacultadService
    {
        public void Add(facultadEscuelaRequest model)
        {
            using (bddSisInvestigacionContext db = new bddSisInvestigacionContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Facultad facultad = new Facultad();
                        facultad.Descripcion = model.descripcion;
                        db.Facultads.Add(facultad);
                        db.SaveChanges();
                        foreach (var modelEscuela in model.especialidades)
                        {
                            var especialidad = new Models.Especialidad();
                            especialidad.Descripcion = modelEscuela.descripcion;
                            especialidad.Idfacultad = facultad.Idfacultad;
                            db.Especialidads.Add(especialidad);
                            db.SaveChanges();
                        }
                        transaction.Commit();                    
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }

        }
    }
    
}
