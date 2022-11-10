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
}
