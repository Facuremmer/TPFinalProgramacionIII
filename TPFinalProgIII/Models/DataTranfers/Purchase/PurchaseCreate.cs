using System;
using System.Collections.Generic;
using TPFinalProgIII.Models.DataTranfers.PurchaseDetail;

namespace TPFinalProgIII.Models.DataTranfers.Purchase
{
    public class PurchaseCreate
    {
        public virtual int idProveedor { get; set; }
        public virtual int TotalCompra { get; set; }
        public virtual DateTime Fecha { get; set; }

        public List<PurchaseDetailCreate> DetallesCompra { get; set; }
    }
}
