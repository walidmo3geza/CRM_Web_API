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
    public ISalesOrderDetailsRepo SalesOrderDetailsRepo { get; }
    public ICustomerRepo CustomerRepo { get; }
    public ICustomerAddressRepo CustomerAddressRepo { get; }
    public ISalesOrderHeaderRepo SalesOrderHeaderRepo { get; }

    public UnitOfWork(IProductRepo productRepo,ISalesOrderDetailsRepo salesOrderDetailsRepo , ICustomerRepo customerRepo, ICustomerAddressRepo customerAddressRepo,ISalesOrderHeaderRepo salesOrderHeaderRepo , ApplicationDbContext context)
    {
        ProductRepo = productRepo;
        SalesOrderDetailsRepo = salesOrderDetailsRepo;
        CustomerRepo = customerRepo;
        CustomerAddressRepo = customerAddressRepo;
        SalesOrderHeaderRepo = salesOrderHeaderRepo;
        this.context = context;
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}
