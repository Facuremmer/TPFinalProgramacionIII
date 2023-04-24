using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.ShippingPurchase;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface IShippingPurchaseServices
    {
        IEnumerable<EnvioCompra> GetAll();
        EnvioCompra GetOne(int shippingPurchaseId);
        void DeleteShippingPurchase(EnvioCompra shippingPurchase);
        EnvioCompra UpdateShippingPurchase(ShippingPurchaseCreateOrUpdate data);
        EnvioCompra CreateShippingPurchase(ShippingPurchaseCreateOrUpdate data);
    }
}
