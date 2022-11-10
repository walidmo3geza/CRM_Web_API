using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public class SalesOrderHeader
{
    public int Id { get; set; }
    public string Status { get; set; } = "";
    public DateTime Date { get; set; }
    public decimal Tax { get; set; } //0.14
    public decimal SubTotal { get; set; } 
    public decimal GrandTotal { get; set; }
    //public CustomerAddress BillingAddress { get; set; } = new CustomerAddress();
    //[ForeignKey("BillingAddress")]
    //public int BillingAddressId { get; set; }
    //public CustomerAddress ShippingAddress { get; set; } = new CustomerAddress();
    //[ForeignKey("ShippingAddress")]
    //public int ShippingAddressId { get; set; }
    public Customer Customer { get; set; } = new Customer();
    public int CustomerId { get; set; }
    public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new HashSet<SalesOrderDetail>();
}
