using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Proveedor> GetAllProviderId()
        {
            return _context.Proveedor.Include(c => c.IdCuitDniNavigation.Proveedor).ToList();
        }

        public Proveedor GetOne(int idProvider)
        {
            return _context.Proveedor.Include(c => c.IdCuitDniNavigation).SingleOrDefault(x => x.IdProveedor == idProvider);
        }

        public IEnumerable<Proveedor> GetByName(string providerName)
        {
            return _context.Proveedor.Where(x => EF.Functions.Like(x.IdCuitDniNavigation.NombreCompleto, $"%{providerName}")).Include(c => c.IdCuitDniNavigation);
        }

        public void DeleteProvider(Proveedor provider)
        {
            _context.Proveedor.Remove(provider);
            _context.SaveChanges();
        }

        public Proveedor UpdateProvider(ProviderCreateOrUpdate data)
        {
            var Provider = GetOne(data.idProvider);
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
