using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public class CustomerAddress
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
    public Customer? Customer { get; set; }
    public int CustomerId { get; set; }
    //public SalesOrderHeader SalesOrderHeader { get; set; } = new SalesOrderHeader();
}
