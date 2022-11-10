using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public class SalesOrderHeader
{
    public int Id { get; set; }
    public string Status { get; set; } = "";
    public DateTime Date { get; set; }

}
