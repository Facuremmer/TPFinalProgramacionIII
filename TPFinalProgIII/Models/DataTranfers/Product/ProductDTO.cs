

namespace TPFinalProgIII.Models.DataTranfers.Product
{
    public class ProductDTO
    {
        public virtual int idProducto { get; set; }
        public virtual string NombreProducto { get; set; }
        public virtual int StockActual { get; set; }
        public virtual double Precio { get; set; }
    }
}
