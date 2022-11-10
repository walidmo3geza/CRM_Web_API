using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;

    public IProductRepo ProductRepo { get; }

    public ICustomerRepo CustomerRepo { get; }

    public ICustomerAddressRepo CustomerAddressRepo { get; }

    public UnitOfWork(IProductRepo productRepo, ICustomerRepo customerRepo, ICustomerAddressRepo customerAddressRepo,ApplicationDbContext context)
    {
        ProductRepo = productRepo;
        CustomerRepo = customerRepo;
        CustomerAddressRepo = customerAddressRepo;
        this.context = context;
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}
