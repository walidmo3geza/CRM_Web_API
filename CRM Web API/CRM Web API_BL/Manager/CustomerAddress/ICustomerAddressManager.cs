using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;

public interface ICustomerAddressManager
{
    List<CustomerAddressReadDTO> GetAllCustomerAddresss();
    CustomerAddressReadDTO GetCustomerAddressById(int id);
    List<CustomerAddressReadDTO> GetAllCustomerAddresssWithAddresses();
    CustomerAddressReadDTO GetCustomerAddressWithAddressesById(int id);
    CustomerAddressReadDTO AddCustomerAddress(CustomerAddressWriteDTO CustomerAddress);
    bool UpdateCustomerAddress(CustomerAddressWriteDTO CustomerAddress);
    bool DeleteCustomerAddress(int id);
}
