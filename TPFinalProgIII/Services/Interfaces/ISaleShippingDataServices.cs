using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.SaleShippingData;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface ISaleShippingDataServices
    {
        IEnumerable<DatosEnvioVenta> GetAll();
        DatosEnvioVenta GetOne(int saleShippingDataId);
        void DeleteSaleShippingData(DatosEnvioVenta saleShippingData);
        DatosEnvioVenta UpdateSaleShippingData(SaleShippingDataCreateOrUpdate data);
        DatosEnvioVenta CreateSaleShippingData(SaleShippingDataCreateOrUpdate data);
    }
}
