using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;

public interface ISalseOrderHeaderManager
{
    List<SalseOrderHeaderReadDTO> GetAllSalseOrderHeaders();
    SalseOrderHeaderReadDTO GetSalseOrderHeaderById(int id);
    SalseOrderHeaderReadDTO AddSalseOrderHeader(SalseOrderHeaderWriteDTO SalseOrderHeader);
    bool UpdateSalseOrderHeader(SalseOrderHeaderWriteDTO SalseOrderHeader);
    bool DeleteSalseOrderHeader(int id);
}
