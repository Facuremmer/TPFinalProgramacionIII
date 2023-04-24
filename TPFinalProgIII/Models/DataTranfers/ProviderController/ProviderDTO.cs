using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.ProviderController
{
    public class ProviderDTO
    {
        public virtual long DNI { get; set; }
        public virtual string NombreCompleto { get; set; }
        public virtual string Rubro { get; set; }
    }
}
