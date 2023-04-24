using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.ShippingPurchase
{
    public class ShippingPurchaseCreateOrUpdate
    {
        public virtual int idCodigoDeSeguimiento { get; set; }
        public virtual int idDetalleCompra { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Sucursal { get; set; }
    }
}
