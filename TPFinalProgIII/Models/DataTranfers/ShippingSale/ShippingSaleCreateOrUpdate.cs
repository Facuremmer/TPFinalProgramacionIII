

namespace TPFinalProgIII.Models.DataTranfers.ShippingSale
{
    public class ShippingSaleCreateOrUpdate
    {
        public virtual int idCodigoDeSeguimiento { get; set; }
        public virtual int idDetalleDeVenta { get; set; }
        public virtual int idDireccion { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Sucursal { get; set; }
    }
}
