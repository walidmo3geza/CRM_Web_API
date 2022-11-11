using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL.Repos;
public class SalesOrderDetailsRepo : GenericRepo<SalesOrderDetail>, ISalesOrderDetailsRepo
{
    private readonly ApplicationDbContext context;
    public SalesOrderDetailsRepo(ApplicationDbContext _context) : base(_context)
    {
        context = _context;
    }
    public List<SalesOrderDetail> GetAllSalesOrders()
    {
        return context.SalesOrderDetails.Include(s => s.SalesOrderHeader).Include(s => s.Product).ToList();
    }

    public SalesOrderDetail? GetSalesOrderDetailById(int id)
    {
        return context.SalesOrderDetails.Include(s => s.SalesOrderHeader).Include(s => s.Product).FirstOrDefault(s => s.Id == id);
    }
}
