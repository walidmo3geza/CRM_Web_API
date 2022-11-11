using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;
public interface ISalesOrderDetailManager
{
    List<SalesOrderDetailsReadDTO> GetAllSalseOrderDetails();
    SalesOrderDetailsReadDTO GetSalseOrderDetailsById(int id);
    SalesOrderDetailsReadDTO AddSalseOrderDetails(SalesOrderDetailsWriteDTO SalseOrderDetails);
    bool UpdateSalseOrderDetails(SalesOrderDetailsWriteDTO SalseOrderDetails);
    bool DeleteSalseOrderDetails(int id);
}
