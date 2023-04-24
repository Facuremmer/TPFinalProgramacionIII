using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Adress;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class AdressServices : BaseServices, IAdressServices
    {
        public AdressServices(StoreContext context)
            : base(context) { }
        public IEnumerable<Direccion> GetAll()
        {
            return _context.Direccion;
        }

        public Direccion GetOne(int adressId)
        {
            return _context.Direccion.SingleOrDefault(x => x.IdDireccion == adressId);
        }

        public void DeleteAdress(Direccion Adress)
        {
            _context.Direccion.Remove(Adress);
            _context.SaveChanges();
        }

        public Direccion UpdateAdress(AdressCreateOrUpdate data)
        {
            var adress = GetOne(data.idDireccion);
            if (adress != null)
            {
                adress.IdCuitDni = data.idCuit_Dni;
                adress.Provincia = data.Provincia;
                adress.Ciudad= data.Ciudad;
                adress.Calle = data.Calle;

                _context.SaveChanges();
            }
            return adress;
        }

        public Direccion CreateAdress(AdressCreateOrUpdate data)
        {
            var adress = new Direccion()
            {
                IdCuitDni = data.idCuit_Dni,
                Provincia = data.Provincia,
                Ciudad = data.Ciudad,
                Calle = data.Calle,
        };

            _context.Direccion.Add(adress);
            _context.SaveChanges();

            return adress;
        }
    }
}
