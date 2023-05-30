
using System.Collections.Generic;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Person;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface IPersonServices
    {
        IEnumerable<Persona> GetAll();
        IEnumerable<Persona> GetAllDni();
        Persona GetOne(long personId);
        IEnumerable<Persona> GetByName(string personName);
        void DeletePerson(Persona person);
        Persona UpdatePerson(PersonDTO data);
        Persona CreatePerson(PersonDTO data);
    }
}
