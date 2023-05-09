using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.Product
{
    public class ProductCreateOrUpdate
    {
        public virtual int idProducto { get; set; }
        public virtual int idTipoProducto { get; set; }
        public virtual int StockActual { get; set; }
    }
}
