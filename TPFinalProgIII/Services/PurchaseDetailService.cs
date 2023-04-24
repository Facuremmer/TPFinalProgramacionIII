using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.PurchaseDetail;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class PurchaseDetailServices : BaseServices, IPurchaseDetailServices
    {
        public PurchaseDetailServices(StoreContext context)
            : base(context) { }
        public IEnumerable<DetalleCompra> GetAll()
        {
            return _context.DetalleCompra.Include(c => c.IdCompraNavigation).ToList();
        }

        public DetalleCompra GetOne(int purchaseDetailId)
        {
            return _context.DetalleCompra.Include(c => c.IdCompraNavigation).SingleOrDefault(x => x.IdDetalleCompra == purchaseDetailId);
        }

        public void DeletePurchaseDetail(DetalleCompra purchaseDetail)
        {
            _context.DetalleCompra.Remove(purchaseDetail);
            _context.SaveChanges();
        }

        public DetalleCompra UpdatePurchaseDetail(PurchaseDetailCreateOrUpdate data)
        {
            var purchaseDetail = GetOne(data.idDetalleCompra);
            if (purchaseDetail != null)
            {
                purchaseDetail.IdCompra = data.idCompra;
                purchaseDetail.IdProducto = data.idProducto;
                purchaseDetail.Precio = data.Precio;
                purchaseDetail.Retencion = data.Retencion;

                _context.SaveChanges();
            }
            return purchaseDetail;
        }

        public DetalleCompra CreatePurchaseDetail(PurchaseDetailCreateOrUpdate data)
        {
            var purchaseDetail = new DetalleCompra()
            {
                IdCompra = data.idCompra,
                IdProducto = data.idProducto,
                Precio= data.Precio,
                Retencion = data.Retencion,
            };

            _context.DetalleCompra.Add(purchaseDetail);
            _context.SaveChanges();

            return purchaseDetail;
        }
    }
}
