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
        Venta GetOne(int saleId);
        void DeleteSale(Venta sale);
        Venta UpdateSale(SaleCreateOrUpdate data);
        Venta CreateSale(SaleCreateOrUpdate data);
    }
}
