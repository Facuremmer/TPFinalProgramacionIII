using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.ProviderController;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class ProviderServices : BaseServices, IProviderServices
    {
        public ProviderServices(StoreContext context)
            : base(context) { }
        public IEnumerable<Proveedor> GetAll()
        {
            return _context.Proveedor.Include(c => c.IdCuitDniNavigation).ToList();
        }

        public Proveedor GetOne(int providerId)
        {
            return _context.Proveedor.Include(c => c.IdCuitDniNavigation).SingleOrDefault(x => x.IdProveedor == providerId);
        }

        public void DeleteProvider(Proveedor provider)
        {
            _context.Proveedor.Remove(provider);
            _context.SaveChanges();
        }

        public Proveedor UpdateProvider(ProviderCreateOrUpdate data)
        {
            var Provider = GetOne(data.idProveedor);
            if (Provider != null)
            {
                Provider.IdCuitDni = data.idCuit_Dni;
                Provider.Rubro = data.Rubro;

                _context.SaveChanges();
            }
            return Provider;
        }

        public Proveedor CreateProvider(ProviderCreateOrUpdate data)
        {
            var provider = new Proveedor()
            {
                IdCuitDni = data.idCuit_Dni,
                Rubro = data.Rubro,
            };

            _context.Proveedor.Add(provider);
            _context.SaveChanges();

            return provider;
        }
    }
}
