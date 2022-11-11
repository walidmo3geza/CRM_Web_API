using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;
public class SalesOrderDetailsWriteDTO
{
    public int Id { get; set; }
    public int LineNo { get; set; }
    public decimal Price { get; set; }
    public int ProductId { get; set; }
    public decimal Qty { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; } //auto calculated
    public int SalesOrderHeaderId { get; set; }
}
