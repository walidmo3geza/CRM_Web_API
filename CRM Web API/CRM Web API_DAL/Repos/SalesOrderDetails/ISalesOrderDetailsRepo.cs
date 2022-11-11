using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public interface ISalesOrderDetailsRepo : IGenericRepo<SalesOrderDetail>
{
    List<SalesOrderDetail> GetAllSalesOrders();
    SalesOrderDetail GetSalesOrderDetailById(int id);
}
