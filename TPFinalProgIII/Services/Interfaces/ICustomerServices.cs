using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models;
using TPFinalProgIII.Models.DataTranfers.Customer;

namespace TPFinalProgIII.Services.Interfaces
{
    public interface ICustomerServices
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetOne(int customerId);
        void DeleteCustomer(Cliente customer);
        Cliente UpdateCustomer(CustomerCreateOrUpdate data);
        Cliente CreateCustomer(CustomerCreateOrUpdate data);
    }
}
