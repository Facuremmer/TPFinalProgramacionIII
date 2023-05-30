

namespace TPFinalProgIII.Models.DataTranfers.PurchaseDetail
{
    public class PurchaseDetailUpdate
    {
        public virtual int idDetalleCompra { get; set; }
        public virtual int idCompra { get; set; }
        public virtual int idProducto { get; set; }
        public virtual int Precio { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual int Retencion { get; set; }

    }
}
