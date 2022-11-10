using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions options) : base(options) { }
	public DbSet<Customer> Customers { get; set; }
	public DbSet<CustomerAddress> CustomerAddresses { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
	public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
}
