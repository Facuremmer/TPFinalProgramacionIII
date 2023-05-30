using System;


namespace TPFinalProgIII.Models.DataTranfers.Purchase
{
    public class PurchaseUpdate
    {
        public virtual int idCompra { get; set; }
        public virtual int idProveedor { get; set; }
        public virtual int TotalCompra { get; set; }
        public virtual DateTime Fecha { get; set; }
    }
}
