using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.ShippingSale;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class ShippingSaleServices : BaseServices, IShippingSaleServices
    {
        public ShippingSaleServices(StoreContext context)
            : base(context) { }
        public IEnumerable<EnvioVenta> GetAll()
        {
            return _context.EnvioVenta;
        }

        public EnvioVenta GetOne(int shippingSaleId)
        {
            return _context.EnvioVenta.SingleOrDefault(x => x.IdCodigoSeguimiento == shippingSaleId);
        }

        public void DeleteShippingSale(EnvioVenta shippingSale)
        {
            _context.EnvioVenta.Remove(shippingSale);
            _context.SaveChanges();
        }

        public EnvioVenta UpdateShippingSale(ShippingSaleCreateOrUpdate data)
        {
            var shippingSale = GetOne(data.idCodigoDeSeguimiento);
            if (shippingSale != null)
            {
                shippingSale.IdDetalleVenta = data.idDetalleDeVenta;
                shippingSale.IdDatosEnvioVenta = data.idDatosEnvioVenta;
                shippingSale.IdDireccion = data.idDireccion;
                shippingSale.Correo = data.Correo;
                shippingSale.Sucursal = data.Sucursal;

                _context.SaveChanges();
            }
            return shippingSale;
        }

        public EnvioVenta CreateShippingSale(ShippingSaleCreateOrUpdate data)
        {
            var shippingSale = new EnvioVenta()
            {
                IdCodigoSeguimiento = data.idCodigoDeSeguimiento,
                IdDetalleVenta = data.idDetalleDeVenta,
                IdDatosEnvioVenta = data.idDatosEnvioVenta,
                IdDireccion = data.idDireccion,
                Correo = data.Correo,
                Sucursal = data.Sucursal,
            };

            _context.EnvioVenta.Add(shippingSale);
            _context.SaveChanges();

            return shippingSale;
        }
    }
}
