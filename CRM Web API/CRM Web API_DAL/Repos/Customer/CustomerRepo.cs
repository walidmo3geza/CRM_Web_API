using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
{
    private readonly ApplicationDbContext context;
    public CustomerRepo(ApplicationDbContext _context) : base(_context)
    {
        context = _context;
    }

    public List<Customer> GetAllCustomersWithAddresses()
    {
        return context.Customers.Include(c => c.Addresses).ToList();
    }

    public Customer? GetCustomerWithAddresses(int id)
    {
        return context.Customers.Include(c => c.Addresses).FirstOrDefault(c => c.Id == id);
    }
}
