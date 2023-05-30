using System;


namespace TPFinalProgIII.Models.DataTranfers.Sale
{
    public class SaleDTO
    {
        public virtual int idVenta { get; set; }
        public virtual int idCliente { get; set; }
        public virtual string SucursalVenta { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual int TotalVenta { get; set; }
    }
}
