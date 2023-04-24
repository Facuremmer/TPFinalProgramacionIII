using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.Sale
{
    public class SaleDTO
    {
        public virtual string SucursalVenta { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual int TotalVenta { get; set; }
    }
}
