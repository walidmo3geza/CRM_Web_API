using CRM_Web_API_DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;

public class SalseOrderHeaderReadDTO
{
    public int Id { get; set; }
    public string Status { get; set; } = "";
    public DateTime Date { get; set; }
    public decimal Tax { get; set; } //0.14
    public decimal SubTotal { get; set; }
    public decimal GrandTotal { get; set; } // SubTotal + Tax
    public CustomerChildReadDTO? Customer { get; set; }
    public int CustomerId { get; set; }
    public ICollection<SalesOrderDetailsChildReadDTO> SalesOrderDetails { get; set; } = new HashSet<SalesOrderDetailsChildReadDTO>();
    public CustomerAddressChildReadDTO? BillingAddress { get; set; }
    public int BillingAddressId { get; set; }
    public CustomerAddressChildReadDTO? ShippingAddress { get; set; }
    public int ShippingAddressId { get; set; }
}
