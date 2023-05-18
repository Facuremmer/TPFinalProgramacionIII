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

        IEnumerable<Compra> GetAllPurchaseId();
        Compra GetOne(int purchaseId);
        IEnumerable<Compra> GetByName(string purchaseName);
        void DeletePurchase(Compra purchase);
        Compra UpdatePurchase(PurchaseUpdate data);
        Compra CreatePurchase(PurchaseCreate data);
    }
}
