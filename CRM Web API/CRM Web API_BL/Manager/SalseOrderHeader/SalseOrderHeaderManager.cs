using AutoMapper;
using CRM_Web_API_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL; 

public class SalseOrderHeaderManager : ISalseOrderHeaderManager
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public SalseOrderHeaderManager(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
    }
    public List<SalseOrderHeaderReadDTO> GetAllSalseOrderHeaders()
    {
        return mapper.Map<List<SalseOrderHeaderReadDTO>>(unitOfWork.SalesOrderHeaderRepo.GetAllSalesOrderHeaders());
    }

    public SalseOrderHeaderReadDTO GetSalseOrderHeaderById(int id)
    {
        return mapper.Map<SalseOrderHeaderReadDTO>(unitOfWork.SalesOrderHeaderRepo.GetSalesOrderHeaderById(id));
    }
    public SalseOrderHeaderReadDTO AddSalseOrderHeader(SalseOrderHeaderWriteDTO SalseOrderHeader)
    {
        var dbSalseOrderHeader = mapper.Map<SalesOrderHeader>(SalseOrderHeader);
        unitOfWork.SalesOrderHeaderRepo.Add(dbSalseOrderHeader);
        unitOfWork.SaveChanges();
        return mapper.Map<SalseOrderHeaderReadDTO>(dbSalseOrderHeader);
    }
    public bool DeleteSalseOrderHeader(int id)
    {
        var dbSalseOrderHeader = unitOfWork.SalesOrderHeaderRepo.GetById(id);
        if (dbSalseOrderHeader != null)
        {
            unitOfWork.SalesOrderHeaderRepo.Delete(dbSalseOrderHeader);
            unitOfWork.SaveChanges();
            return true;
        }
        return false;
    }
    public bool UpdateSalseOrderHeader(SalseOrderHeaderWriteDTO SalseOrderHeader)
    {
        var dbSalseOrderHeader = unitOfWork.SalesOrderHeaderRepo.GetById(SalseOrderHeader.Id);
        if (dbSalseOrderHeader != null)
        {
            dbSalseOrderHeader.Status = SalseOrderHeader.Status;
            dbSalseOrderHeader.Date = SalseOrderHeader.Date;
            dbSalseOrderHeader.SubTotal = SalseOrderHeader.SubTotal;
            dbSalseOrderHeader.Tax = SalseOrderHeader.Tax;
            dbSalseOrderHeader.GrandTotal = SalseOrderHeader.GrandTotal;
            dbSalseOrderHeader.ShippingAddressId = SalseOrderHeader.ShippingAddressId;
            dbSalseOrderHeader.BillingAddressId = SalseOrderHeader.BillingAddressId;
            dbSalseOrderHeader.CustomerId = SalseOrderHeader.CustomerId;
            
            unitOfWork.SaveChanges();
            return true;
        }
        return false;
    }
}
