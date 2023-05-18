using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.Customer
{
    public class CustomerDTO
    {
        public virtual int Id { get; set; }
        public virtual long DNI { get; set; }
        public virtual string NombreCompleto { get; set; }
    }
}
