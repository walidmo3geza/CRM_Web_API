using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_DAL;

public interface IUnitOfWork
{
    public IProductRepo ProductRepo { get; }
    public ICustomerRepo CustomerRepo { get; }
    public ICustomerAddressRepo CustomerAddressRepo { get; }
    public ISalesOrderHeaderRepo SalesOrderHeaderRepo { get; }
    public ISalesOrderDetailsRepo SalesOrderDetailsRepo { get; }
    public void SaveChanges();
}
