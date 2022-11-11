using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public interface ISalesOrderHeaderRepo : IGenericRepo<SalesOrderHeader>
{
    List<SalesOrderHeader> GetAllSalesOrderHeaders();
    SalesOrderHeader GetSalesOrderHeaderById(int id);
}
