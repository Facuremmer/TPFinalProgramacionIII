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
        IEnumerable<Direccion> GetAllAdressId();
        Direccion GetOne(int adressId);
        IEnumerable<Direccion> GetByName(string adressName);
        void DeleteAdress(Direccion adress);
        Direccion UpdateAdress(AdressUpdate data);
        Direccion CreateAdress (AdressCreate data);
    }
}
