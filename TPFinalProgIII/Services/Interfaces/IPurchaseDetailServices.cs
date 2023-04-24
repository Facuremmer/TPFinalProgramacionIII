using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.PurchaseDetail;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface IPurchaseDetailServices
    {
        IEnumerable<DetalleCompra> GetAll();
        DetalleCompra GetOne(int purchaseDetailId);
        void DeletePurchaseDetail(DetalleCompra purchaseDetail);
        DetalleCompra UpdatePurchaseDetail(PurchaseDetailCreateOrUpdate data);
        DetalleCompra CreatePurchaseDetail(PurchaseDetailCreateOrUpdate data);
    }
}
