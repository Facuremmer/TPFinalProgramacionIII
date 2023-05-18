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
        IEnumerable<Cliente> GetAllCustomerId();
        Cliente GetOne(int customerId);
        IEnumerable<Cliente> GetByName(string customerName);
        void DeleteCustomer(Cliente customer);
        Cliente UpdateCustomer(CustomerUpdate data);
        Cliente CreateCustomer(CustomerCreate data);
    }
}
