using System;
using System.Collections.Generic;
using TPFinalProgIII.Models.DataTranfers.SaleDetail;

namespace TPFinalProgIII.Models.DataTranfers.Sale
{
    public class SaleCreate
    {
        public virtual int idCliente { get; set; }
        public virtual string SucursalVenta { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual int TotalVenta { get; set; }

        public List<SaleDetailCreate> DetallesVenta { get; set; }
    }
}
