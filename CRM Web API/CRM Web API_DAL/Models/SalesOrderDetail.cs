using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public class SalesOrderDetail
{
    public int Id { get; set; }
    public int LineNo { get; set; }
    public decimal Price { get; set; }
    public Product Product { get; set; } = new Product();
    public int ProductId { get; set; }
    public decimal Qty { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; } //auto calculated
    public SalesOrderHeader SalesOrderHeader { get; set; } = new SalesOrderHeader();
    public int SalesOrderHeaderId { get; set; }
}
