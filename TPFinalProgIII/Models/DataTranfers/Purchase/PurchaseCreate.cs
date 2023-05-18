﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPFinalProgIII.Models.DataTranfers.Purchase
{
    public class PurchaseCreate
    {
        public virtual int idProveedor { get; set; }
        public virtual int TotalCompra { get; set; }
        public virtual DateTime Fecha { get; set; }
    }
}