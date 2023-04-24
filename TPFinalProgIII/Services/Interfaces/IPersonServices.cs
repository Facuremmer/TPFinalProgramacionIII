using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Person;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface IPersonServices
    {
        IEnumerable<Persona> GetAll();
        Persona GetOne(long personId);
        void DeletePerson(Persona person);
        Persona UpdatePerson(PersonCreateOrUpdate data);
        Persona CreatePerson(PersonCreateOrUpdate data);
    }
}
