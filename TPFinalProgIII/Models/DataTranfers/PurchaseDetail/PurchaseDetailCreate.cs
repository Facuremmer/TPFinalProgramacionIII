﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.PurchaseDetail
{
    public class PurchaseDetailCreate
    {
        public virtual int idCompra { get; set; }
        public virtual int idProducto  { get; set; }
        public virtual int Precio { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual int Retencion { get; set; }
    }
}
