using System;


namespace TPFinalProgIII.Models.DataTranfers.Purchase
{
    public class PurchaseDTO
    {
        public virtual int idCompra { get; set; }
        // public virtual long idCuit_Dni { get; set; }
        // public virtual string nombreProveedor { get; set; }
        public virtual int idProveedor { get; set; }
        public virtual string Rubro { get; set; }
        public virtual int TotalCompra { get; set; }
        public virtual DateTime Fecha { get; set; }
    }
}
