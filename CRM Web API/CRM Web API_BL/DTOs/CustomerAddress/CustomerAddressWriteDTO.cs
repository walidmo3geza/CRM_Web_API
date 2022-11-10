using CRM_Web_API_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;

public class CustomerAddressWriteDTO
{
    public int Id { get; set; }
    public string AddressLine_1 { get; set; } = "";
    public string AddressLine_2 { get; set; } = "";
    public string City { get; set; } = "";
    public string State { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string Country { get; set; } = "";
    public bool ShippingAddressFlag { get; set; }
    public bool BillingAddressFlag { get; set; }
    //public CustomerChildReadDTO Customer { get; set; } = new CustomerChildReadDTO();
    public int CustomerId { get; set; }
}
