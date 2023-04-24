using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.ShippingSale
{
    public class ShippingSaleDTO
    {
        public virtual string idCodigoDeSeguimiento { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Sucursal { get; set; }
    }
}
