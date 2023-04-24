using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.SaleDetail;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface ISaleDetailServices
    {
        IEnumerable<DetalleVenta> GetAll();
        DetalleVenta GetOne(int saleDetailId);
        void DeleteSaleDetail(DetalleVenta saleDetail);
        DetalleVenta UpdateSaleDetail(SaleDetailCreateOrUpdate data);
        DetalleVenta CreateSaleDetail(SaleDetailCreateOrUpdate data);
    }
}
