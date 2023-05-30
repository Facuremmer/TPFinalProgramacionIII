using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Person;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class PersonServices : BaseServices, IPersonServices
    {
        public PersonServices(StoreContext context)
            : base(context) { }
        public IEnumerable<Persona> GetAll()
        {
            return _context.Persona;
        }

        public IEnumerable<Persona> GetAllDni()
        {
            return _context.Persona;
        }

        public Persona GetOne(long personId)
        {
            return _context.Persona.SingleOrDefault(x => x.IdCuitDni == personId);
        }

        public IEnumerable<Persona> GetByName(string personName)
        {
            return _context.Persona.Where(x => EF.Functions.Like(x.NombreCompleto, $"%{personName}"));
        }


        public void DeletePerson(Persona person)
        {
            _context.Persona.Remove(person);
            _context.SaveChanges();
        }

        public Persona UpdatePerson(PersonDTO data)
        {
            var person = GetOne(data.idCuit_Dni);
            if (person != null)
            {
                person.NombreCompleto = data.NombreCompleto;
                _context.SaveChanges();
            }
            return person;
        }

        public Persona CreatePerson(PersonDTO data)
        {
            var person = new Persona()
            {
                IdCuitDni = data.idCuit_Dni,
                NombreCompleto = data.NombreCompleto,
            };

            _context.Persona.Add(person);
            _context.SaveChanges();

            return person;
        }
    }
}
