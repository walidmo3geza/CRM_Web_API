using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;

public class SalseOrderHeaderChildReadDTO
{
    public int Id { get; set; }
    public string Status { get; set; } = "";
    public DateTime Date { get; set; }
    public decimal Tax { get; set; } //0.14
    public decimal SubTotal { get; set; }
    public decimal GrandTotal { get; set; } // SubTotal + Tax
    public int CustomerId { get; set; }
    public int BillingAddressId { get; set; }
    public int ShippingAddressId { get; set; }
}
