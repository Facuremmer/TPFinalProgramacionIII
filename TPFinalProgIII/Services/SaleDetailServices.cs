using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.SaleDetail;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class SaleDetailServices : BaseServices, ISaleDetailServices
    {
        public SaleDetailServices(StoreContext context)
            : base(context) { }
        public IEnumerable<DetalleVenta> GetAll()
        {
            return _context.DetalleVenta;
        }

        public DetalleVenta GetOne(int saleDetailId)
        {
            return _context.DetalleVenta.SingleOrDefault(x => x.IdDetalleVenta == saleDetailId);
        }

        public void DeleteSaleDetail(DetalleVenta saleDetail)
        {
            _context.DetalleVenta.Remove(saleDetail);
            _context.SaveChanges();
        }

        public DetalleVenta UpdateSaleDetail(SaleDetailCreateOrUpdate data)
        {
            var saleDetail = GetOne(data.idDetalleVenta);
            if (saleDetail != null)
            {
                saleDetail.IdVenta = data.idVenta;
                saleDetail.IdProducto = data.idProducto;
                saleDetail.Precio = data.Precio;
                saleDetail.Recargo = data.Recargo;

                _context.SaveChanges();
            }
            return saleDetail;
        }

        public DetalleVenta CreateSaleDetail(SaleDetailCreateOrUpdate data)
        {
            var saleDetail = new DetalleVenta()
            {
                IdProducto = data.idProducto,
                IdVenta = data.idVenta,
                Precio = data.Precio,
                Recargo = data.Recargo,
            };

            _context.DetalleVenta.Add(saleDetail);
            _context.SaveChanges();

            return saleDetail;
        }
    }
}
