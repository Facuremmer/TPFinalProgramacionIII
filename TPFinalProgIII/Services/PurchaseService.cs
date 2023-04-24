using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Purchase;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class PurchaseServices : BaseServices, IPurchaseServices
    {
        public PurchaseServices(StoreContext context)
            : base(context) { }
        public IEnumerable<Compra> GetAll()
        {
            return _context.Compra;
        }

        public Compra GetOne(int purchaseId)
        {
            return _context.Compra.SingleOrDefault(x => x.IdCompra == purchaseId);
        }

        public void DeletePurchase(Compra purchase)
        {
            _context.Compra.Remove(purchase);
            _context.SaveChanges();
        }

        public Compra UpdatePurchase(PurchaseCreateOrUpdate data)
        {
            var purchase = GetOne(data.idCompra);
            if (purchase != null)
            {
                purchase.TotalCompra= data.TotalCompra;
                purchase.Fecha = data.Fecha;

                _context.SaveChanges();
            }
            return purchase;
        }

        public Compra CreatePurchase(PurchaseCreateOrUpdate data)
        {
            var purchase = new Compra()
            {
                IdProveedor = data.idProveedor,
                TotalCompra = data.TotalCompra,
                Fecha = data.Fecha,
            };

            _context.Compra.Add(purchase);
            _context.SaveChanges();

            return purchase;
        }
    }
}
