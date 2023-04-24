using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.ShippingPurchase;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class ShippingPurchaseServices : BaseServices, IShippingPurchaseServices
    {
        public ShippingPurchaseServices(StoreContext context)
            : base(context) { }
        public IEnumerable<EnvioCompra> GetAll()
        {
            return _context.EnvioCompra;
        }

        public EnvioCompra GetOne(int shippingPurchaseId)
        {
            return _context.EnvioCompra.SingleOrDefault(x => x.IdCodigoSeguimiento == shippingPurchaseId);
        }

        public void DeleteShippingPurchase(EnvioCompra shippingPurchase)
        {
            _context.EnvioCompra.Remove(shippingPurchase);
            _context.SaveChanges();
        }

        public EnvioCompra UpdateShippingPurchase(ShippingPurchaseCreateOrUpdate data)
        {
            var shippingPurchase = GetOne(data.idCodigoDeSeguimiento);
            if (shippingPurchase != null)
            {
                shippingPurchase.IdDetalleCompra = data.idDetalleCompra;
                shippingPurchase.Correo= data.Correo;
                shippingPurchase.Sucursal = data.Sucursal;

                _context.SaveChanges();
            }
            return shippingPurchase;
        }

        public EnvioCompra CreateShippingPurchase(ShippingPurchaseCreateOrUpdate data)
        {
            var shippingPurchase = new EnvioCompra()
            {
                IdCodigoSeguimiento = data.idCodigoDeSeguimiento,
                IdDetalleCompra = data.idDetalleCompra,
                Correo = data.Correo,
                Sucursal = data.Sucursal,
            };

            _context.EnvioCompra.Add(shippingPurchase);
            _context.SaveChanges();

            return shippingPurchase;
        }
    } 
}
