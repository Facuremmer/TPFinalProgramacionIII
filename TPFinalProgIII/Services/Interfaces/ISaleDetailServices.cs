
using System.Collections.Generic;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.SaleDetail;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface ISaleDetailServices
    {
        IEnumerable<DetalleVenta> GetAll();
        IEnumerable<DetalleVenta> GetAllSaleDetailId();
        DetalleVenta GetOne(int saleDetailId);
        IEnumerable<DetalleVenta> GetByName(string branchName);
        void DeleteSaleDetail(DetalleVenta saleDetail);
        DetalleVenta UpdateSaleDetail(SaleDetaiUpdate data);
        DetalleVenta CreateSaleDetail(SaleDetailCreate data);
    }
}
