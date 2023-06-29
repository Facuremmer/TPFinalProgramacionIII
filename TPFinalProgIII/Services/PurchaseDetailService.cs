using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<DetalleCompra> GetAllpurchaseDetailId()
        {
            return _context.DetalleCompra;
        }

        public DetalleCompra GetOne(int purchaseDetailId)
        {
            return _context.DetalleCompra.Include(c => c.IdCompraNavigation).SingleOrDefault(x => x.IdDetalleCompra == purchaseDetailId);
        }

        public IEnumerable<DetalleCompra> GetByName(string CompraDetailName)
        {
            return _context.DetalleCompra.Where(x => EF.Functions.Like(x.IdCompraNavigation.IdProveedorNavigation.IdCuitDniNavigation.NombreCompleto, $"%{CompraDetailName}")).Include(c => c.IdCompraNavigation.IdProveedorNavigation.IdCuitDniNavigation);
        }

        public void DeletePurchaseDetail(DetalleCompra purchaseDetail)
        {
            _context.DetalleCompra.Remove(purchaseDetail);
            _context.SaveChanges();
        }

        public DetalleCompra UpdatePurchaseDetail(PurchaseDetailUpdate data)
        {
            var purchaseDetail = GetOne(data.idDetalleCompra);
            if (purchaseDetail != null)
            {
                purchaseDetail.IdCompra = data.idCompra;
                purchaseDetail.IdProducto = data.idProducto;
                purchaseDetail.Precio = data.Precio;
                purchaseDetail.Cantidad = data.Cantidad;
                purchaseDetail.Retencion = data.Retencion;

                _context.SaveChanges();
            }
            return purchaseDetail;
        }

    }
}
