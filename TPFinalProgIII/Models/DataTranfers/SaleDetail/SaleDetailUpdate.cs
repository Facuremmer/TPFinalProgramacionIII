﻿

namespace TPFinalProgIII.Models.DataTranfers.SaleDetail
{
    public class SaleDetaiUpdate
    {
        public virtual int idDetalleVenta { get; set; }
        public virtual int idVenta { get; set; }
        public virtual int idProducto { get; set; }
        public virtual int Precio { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual int Descuento { get; set; }
        public virtual int Recargo { get; set; }
    }
}
