using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public interface ICustomerAddressRepo : IGenericRepo<CustomerAddress>
{
    List<CustomerAddress> GetAllCustomerAddressesWithCustomer();
    CustomerAddress GetCustomerAddressWithCustomerByID(int id);
}
