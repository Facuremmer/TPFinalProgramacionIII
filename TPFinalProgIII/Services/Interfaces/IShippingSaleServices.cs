﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.ShippingSale;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface IShippingSaleServices
    {
        IEnumerable<EnvioVenta> GetAll();
        EnvioVenta GetOne(int shippingSaleId);
        void DeleteShippingSale(EnvioVenta shippingSale);
        EnvioVenta UpdateShippingSale(ShippingSaleCreateOrUpdate data);
        EnvioVenta CreateShippingSale(ShippingSaleCreateOrUpdate data);
    }
}
