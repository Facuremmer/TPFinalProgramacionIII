

namespace TPFinalProgIII.Models.DataTranfers.ShippingPurchase
{
    public class ShippingPurchaseDTO
    {
        public virtual long idCodigoDeSeguimiento { get; set; }
        public virtual int idDetalleCompra { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Sucursal { get; set; }
    }
}
