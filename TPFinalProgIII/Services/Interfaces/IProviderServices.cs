using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.ProviderController;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface IProviderServices
    {
        IEnumerable<Proveedor> GetAll();
        Proveedor GetOne(int providerId);
        void DeleteProvider(Proveedor provider);
        Proveedor UpdateProvider(ProviderCreateOrUpdate data);
        Proveedor CreateProvider(ProviderCreateOrUpdate data);
    }
}
