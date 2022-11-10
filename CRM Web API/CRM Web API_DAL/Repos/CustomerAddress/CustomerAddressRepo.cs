using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public class CustomerAddressRepo : GenericRepo<CustomerAddress>, ICustomerAddressRepo
{
    private readonly ApplicationDbContext context;
    public CustomerAddressRepo(ApplicationDbContext _context) : base(_context)
    {
        context = _context;
    }

    public List<CustomerAddress> GetAllCustomerAddressesWithCustomer()
    {
        return context.CustomerAddresses.Include(c => c.Customer).ToList();
    }

    public CustomerAddress? GetCustomerAddressWithCustomerByID(int id)
    {
        return context.CustomerAddresses.Include(c => c.Customer).FirstOrDefault(c => c.Id == id);
    }
}
