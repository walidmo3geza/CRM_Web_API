using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public class ProductRepo : GenericRepo<Product>, IProductRepo
{
    private readonly ApplicationDbContext context;
    public ProductRepo(ApplicationDbContext _context) : base(_context)
    {
        context = _context;
    }

}
