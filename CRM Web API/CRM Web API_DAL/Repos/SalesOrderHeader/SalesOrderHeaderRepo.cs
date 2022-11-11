using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;
public class SalesOrderHeaderRepo : GenericRepo<SalesOrderHeader>, ISalesOrderHeaderRepo
{
	private readonly ApplicationDbContext context;
	public SalesOrderHeaderRepo(ApplicationDbContext _context) : base(_context)
	{
		context = _context;
	}
	public List<SalesOrderHeader> GetAllSalesOrderHeaders()
	{
		return context.SalesOrderHeaders
			.Include(s => s.Customer)
			.Include(s => s.ShippingAddress)
			.Include(s => s.BillingAddress)
			.Include(s => s.SalesOrderDetails)
			.ToList();
	}

	public SalesOrderHeader? GetSalesOrderHeaderById(int id)
	{
		return context.SalesOrderHeaders
			.Include(s => s.Customer)
			.Include(s => s.ShippingAddress)
			.Include(s => s.BillingAddress)
			.Include(s => s.SalesOrderDetails)
			.FirstOrDefault(s => s.Id == id);
    }
}
