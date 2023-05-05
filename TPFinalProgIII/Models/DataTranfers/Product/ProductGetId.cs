using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.Product
{
    public class ProductGetId
    {
        public virtual int idProducto { get; set; }
        public virtual string NombreProducto { get; set; }
        public virtual long CodigoProducto { get; set; }
        public virtual int StockActual { get; set; }
    }
}
