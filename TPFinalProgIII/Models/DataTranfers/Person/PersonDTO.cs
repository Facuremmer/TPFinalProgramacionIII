using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.Person
{
    public class PersonDTO
    {
        public virtual long idCuit_Dni { get; set; }
        public virtual string NombreCompleto { get; set; }
    }
}
