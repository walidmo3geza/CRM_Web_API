using AutoMapper;
using CRM_Web_API_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;

public class SalesOrderDetailManager : ISalesOrderDetailManager
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public SalesOrderDetailManager(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
    }
    public List<SalesOrderDetailsReadDTO> GetAllSalseOrderDetails()
    {
        return mapper.Map<List<SalesOrderDetailsReadDTO>>(unitOfWork.SalesOrderDetailsRepo.GetAllSalesOrders());
    }

    public SalesOrderDetailsReadDTO GetSalseOrderDetailsById(int id)
    {
        return mapper.Map<SalesOrderDetailsReadDTO>(unitOfWork.SalesOrderDetailsRepo.GetSalesOrderDetailById(id));
    }
    public SalesOrderDetailsReadDTO AddSalseOrderDetails(SalesOrderDetailsWriteDTO SalseOrderDetail)
    {
        var dbSalseOrderDetail = mapper.Map<SalesOrderDetail>(SalseOrderDetail);
        unitOfWork.SalesOrderDetailsRepo.Add(dbSalseOrderDetail);
        unitOfWork.SaveChanges();
        return mapper.Map<SalesOrderDetailsReadDTO>(dbSalseOrderDetail);
    }
    public bool DeleteSalseOrderDetails(int id)
    {
        var dbSalseOrderDetail = unitOfWork.SalesOrderDetailsRepo.GetById(id);
        if (dbSalseOrderDetail != null)
        {
            unitOfWork.SalesOrderDetailsRepo.Delete(dbSalseOrderDetail);
            unitOfWork.SaveChanges();
            return true;
        }
        return false;
    }
    public bool UpdateSalseOrderDetails(SalesOrderDetailsWriteDTO SalseOrderDetail)
    {
        var dbSalseOrderDetail = unitOfWork.SalesOrderDetailsRepo.GetById(SalseOrderDetail.Id);
        if (dbSalseOrderDetail != null)
        {
            dbSalseOrderDetail.LineNo = SalseOrderDetail.LineNo;
            dbSalseOrderDetail.Price = SalseOrderDetail.Price;
            dbSalseOrderDetail.ProductId = SalseOrderDetail.ProductId;
            dbSalseOrderDetail.Tax = SalseOrderDetail.Tax;
            dbSalseOrderDetail.Qty = SalseOrderDetail.Qty;
            dbSalseOrderDetail.Total = SalseOrderDetail.Total;
            dbSalseOrderDetail.SalesOrderHeaderId = SalseOrderDetail.SalesOrderHeaderId;
            unitOfWork.SaveChanges();
            return true;
        }
        return false;
    }
}
