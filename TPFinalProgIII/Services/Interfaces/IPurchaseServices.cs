using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Purchase;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface IPurchaseServices
    {
        IEnumerable<Compra> GetAll();
        Compra GetOne(int purchaseId);
        void DeletePurchase(Compra purchase);
        Compra UpdatePurchase(PurchaseCreateOrUpdate data);
        Compra CreatePurchase(PurchaseCreateOrUpdate data);
    }
}
