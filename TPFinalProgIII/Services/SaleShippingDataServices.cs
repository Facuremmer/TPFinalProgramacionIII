using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.SaleShippingData;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class SaleShippingDataServices : BaseServices, ISaleShippingDataServices
    {
        public SaleShippingDataServices(StoreContext context)
            : base(context) { }
        public IEnumerable<DatosEnvioVenta> GetAll()
        {
            return _context.DatosEnvioVenta;
        }

        public DatosEnvioVenta GetOne(int saleShippingDataId)
        {
            return _context.DatosEnvioVenta.SingleOrDefault(x => x.IdDatosEnvioVenta == saleShippingDataId);
        }

        public void DeleteSaleShippingData(DatosEnvioVenta saleShippingData)
        {
            _context.DatosEnvioVenta.Remove(saleShippingData);
            _context.SaveChanges();
        }

        public DatosEnvioVenta UpdateSaleShippingData(SaleShippingDataCreateOrUpdate data)
        {
            var saleShippingData = GetOne(data.idDatosEnvioVenta);
            if (saleShippingData != null)
            {
                saleShippingData.NombreCompleto = data.NombreCompleto;
                saleShippingData.Provincia= data.Provincia;
                saleShippingData.Ciudad = data.Ciudad;
                saleShippingData.Calle = data.Aclaraciones; 
                saleShippingData.Numero = data.Numero;
                saleShippingData.Aclaraciones = data.Aclaraciones;

                _context.SaveChanges();
            }
            return saleShippingData;
        }

        public DatosEnvioVenta CreateSaleShippingData(SaleShippingDataCreateOrUpdate data)
        {
            var saleShippingData = new DatosEnvioVenta()
            {
                NombreCompleto = data.NombreCompleto,
                Provincia = data.Provincia,
                Ciudad = data.Ciudad,
                Calle = data.Aclaraciones,
                Numero = data.Numero,
                Aclaraciones = data.Aclaraciones,
            };

            _context.DatosEnvioVenta.Add(saleShippingData);
            _context.SaveChanges();

            return saleShippingData;
        }
    }
}
