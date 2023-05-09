using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.ProductType
{
    public class ProductTypeDTO
    {
        public virtual int idTipoProducto { get; set; }
        public virtual string Descripcion { get; set; }
    }
}
