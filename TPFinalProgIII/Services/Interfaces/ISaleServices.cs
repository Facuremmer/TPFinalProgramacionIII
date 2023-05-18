using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Sale;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface ISaleServices
    {
        IEnumerable<Venta> GetAll();
        IEnumerable<Venta> GetAllSaleId();
        Venta GetOne(int saleId);
        IEnumerable<Venta> GetByName(string branchName);
        void DeleteSale(Venta sale);
        Venta UpdateSale(SaleUpdate data);
        Venta CreateSale(SaleCreate data);
    }
}
