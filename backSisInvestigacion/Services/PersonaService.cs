using backSisInvestigacion.Models;
using backSisInvestigacion.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backSisInvestigacion.Services
{
    public class PersonaService : IPersonaService
    {
        public Persona GetById(int id)
        {
            //PersonaResponse persona = new PersonaResponse();

          
                using (bddSisInvestigacionContext db = new bddSisInvestigacionContext())
                {

                Persona persona=db.Personas.Find(id);
                return persona;

            }
          
           

           
        }

    }
}
