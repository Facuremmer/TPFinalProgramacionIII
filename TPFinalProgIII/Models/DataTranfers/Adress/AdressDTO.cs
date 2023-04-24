using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.Adress
{
    public class AdressDTO
    {
        public virtual string Provincia { get; set; }
        public virtual string Ciudad { get; set; }
        public virtual string Calle{ get; set; }
    }
}
