using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.SaleDetail
{
    public class SaleDetailDTO
    {
        public virtual int Precio { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual int Descuento { get; set; }
        public virtual int Recargo { get; set; }
    }
}
