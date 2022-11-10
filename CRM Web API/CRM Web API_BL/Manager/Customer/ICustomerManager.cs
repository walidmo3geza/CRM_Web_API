using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;

public interface ICustomerManager
{
    List<CustomerReadDTO> GetAllCustomers();
    CustomerReadDTO GetCustomerById(int id);
    List<CustomerReadDTO> GetAllCustomersWithAddresses();
    CustomerReadDTO GetCustomerWithAddressesById(int id);
    CustomerReadDTO AddCustomer(CustomerWriteDto Customer);
    bool UpdateCustomer(CustomerWriteDto Customer);
    bool DeleteCustomer(int id);
}
