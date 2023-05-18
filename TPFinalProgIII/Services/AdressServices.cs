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
            return _context.Direccion.Include(c => c.IdCuitDniNavigation).ToList(); ;
        }

        public IEnumerable<Direccion> GetAllAdressId()
        {
            return _context.Direccion.Include(c => c.IdCuitDniNavigation).ToList();
        }

        public Direccion GetOne(int adressId)
        {
            return _context.Direccion.SingleOrDefault(x => x.IdDireccion == adressId);
        }

        public IEnumerable<Direccion> GetByName(string adressName)
        {
            return _context.Direccion.Where(x => EF.Functions.Like(x.Calle, $"%{adressName}")).Include(c => c.IdCuitDniNavigation);
        }

        public void DeleteAdress(Direccion Adress)
        {
            _context.Direccion.Remove(Adress);
            _context.SaveChanges();
        }

        public Direccion UpdateAdress(AdressUpdate data)
        {
            var adress = GetOne(data.idDireccion);
            if (adress != null)
            {
                adress.IdCuitDni = data.Dni;
                adress.Provincia = data.Provincia;
                adress.Ciudad= data.Ciudad;
                adress.Calle = data.Calle;
                adress.Numero = data.Numero;

                _context.SaveChanges();
            }
            return adress;
        }

        public Direccion CreateAdress(AdressCreate data)
        {
            var adress = new Direccion()
            {
                IdCuitDni = data.idCuit_Dni,
                Provincia = data.Provincia,
                Ciudad = data.Ciudad,
                Calle = data.Calle,
                Numero = data.Numero,
            };

            _context.Direccion.Add(adress);
            _context.SaveChanges();

            return adress;
        }
    }
}
