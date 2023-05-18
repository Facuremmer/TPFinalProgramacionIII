using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Customer;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Services
{
    public class CustomerServices : BaseServices, ICustomerServices
    {
        public CustomerServices(StoreContext context)
            : base(context) { }
        public IEnumerable<Cliente> GetAll()
        {
            return _context.Cliente.Include(c => c.IdCuitDniNavigation).ToList();
        }

        public IEnumerable<Cliente> GetAllCustomerId()
        {
            return _context.Cliente.Include(c => c.IdCuitDniNavigation.Cliente).ToList();
        }

        public Cliente GetOne(int customerId)
        {
            return _context.Cliente.SingleOrDefault(x => x.IdCliente == customerId);
        }

        public IEnumerable<Cliente> GetByName(string customerName)
        {
            return _context.Cliente.Where(x => EF.Functions.Like(x.IdCuitDniNavigation.NombreCompleto, $"%{customerName}")).Include(c => c.IdCuitDniNavigation);
        }

        public void DeleteCustomer(Cliente customer)
        {
            _context.Cliente.Remove(customer);
            _context.SaveChanges();
        }

        public Cliente UpdateCustomer(CustomerUpdate data)
        {
            var customer = GetOne(data.idCliente);
            if (customer != null)
            {
                customer.IdCliente = data.idCliente;
                customer.IdCuitDni = data.idCuit_Dni;

                _context.SaveChanges();
            }
            return customer;
        }

        public Cliente CreateCustomer(CustomerCreate data)
        {
            var customer = new Cliente()
            {
                IdCuitDni = data.idCuit_Dni,
            };

            _context.Cliente.Add(customer);
            _context.SaveChanges();

            return customer;
        }
    }
}
