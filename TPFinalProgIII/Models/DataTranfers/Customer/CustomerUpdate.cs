using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.Customer
{
    public class CustomerUpdate
    {
        public virtual int idCliente { get; set; }
        public virtual long idCuit_Dni { get; set; }
    }
}
