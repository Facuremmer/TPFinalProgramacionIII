
using System.Collections.Generic;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.PurchaseDetail;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface IPurchaseDetailServices
    {
        IEnumerable<DetalleCompra> GetAll();
        IEnumerable<DetalleCompra> GetAllpurchaseDetailId();
        DetalleCompra GetOne(int purchaseDetailId);
        IEnumerable<DetalleCompra> GetByName(string purchaseDetailName);
        void DeletePurchaseDetail(DetalleCompra purchaseDetail);
        DetalleCompra UpdatePurchaseDetail(PurchaseDetailUpdate data);
    }
}
