using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Sale;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class SaleServices : BaseServices, ISaleServices
    {
        public SaleServices(StoreContext context)
            : base(context) { }
        public IEnumerable<Venta> GetAll()
        {
            return _context.Venta;
        }

        public IEnumerable<Venta> GetAllSaleId()
        {
            return _context.Venta;
        }

        public Venta GetOne(int saleId)
        {
            return _context.Venta.SingleOrDefault(x => x.IdVenta == saleId);
        }

        public IEnumerable<Venta> GetByName(string branchName)
        {
            return _context.Venta.Where(x => EF.Functions.Like(x.SucursalVenta, $"%{branchName}"));
        }

        public void DeleteSale(Venta sale)
        {
            _context.Venta.Remove(sale);
            _context.SaveChanges();
        }

        public Venta UpdateSale(SaleUpdate data)
        {
            var sale = GetOne(data.idVenta);
            if (sale != null)
            {
                sale.IdCliente= data.idCliente;
                sale.SucursalVenta = data.SucursalVenta;
                sale.TotalVenta = data.TotalVenta;
                sale.Fecha = data.Fecha;

                _context.SaveChanges();
            }
            return sale;
        }

        public Venta CreateSale(SaleCreate data)
        {
            var sale = new Venta()
            {
                IdCliente = data.idCliente,
                SucursalVenta = data.SucursalVenta,
                TotalVenta = data.TotalVenta,
                Fecha = data.Fecha,
            };

            _context.Venta.Add(sale);
            _context.SaveChanges();

            return sale;
        }
    }
}
