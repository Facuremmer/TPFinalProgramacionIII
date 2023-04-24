using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Adress;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface IAdressServices
    {
        IEnumerable<Direccion> GetAll();
        Direccion GetOne(int adressId);
        void DeleteAdress(Direccion adress);
        Direccion UpdateAdress(AdressCreateOrUpdate data);
        Direccion CreateAdress (AdressCreateOrUpdate data);
    }
}
