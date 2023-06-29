using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            var venta = new Venta()
            {
                IdCliente = data.idCliente,
                SucursalVenta = data.SucursalVenta,
                TotalVenta = data.TotalVenta,
                Fecha = data.Fecha,
                DetalleVenta = new List<DetalleVenta>() // Inicializar la lista de detalles de venta
            };

            // Agregar los detalles de venta
            foreach (var detalleData in data.DetallesVenta)
            {
                var detalleVenta = new DetalleVenta()
                {
                    IdVenta = detalleData.idVenta,
                    IdProducto = detalleData.idProducto,
                    Precio = detalleData.Precio,
                    Cantidad = detalleData.Cantidad,
                    Descuento = detalleData.Descuento,
                    Recargo = detalleData.Recargo
                };

                venta.DetalleVenta.Add(detalleVenta);
            }

            _context.Venta.Add(venta);
            _context.SaveChanges();

            return venta;
        }
    }
}
