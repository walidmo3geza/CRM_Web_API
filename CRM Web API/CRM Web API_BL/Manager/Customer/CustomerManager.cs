using AutoMapper;
using CRM_Web_API_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;

public class CustomerManager : ICustomerManager
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public CustomerManager(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
    }
    public List<CustomerReadDTO> GetAllCustomersWithAddresses()
    {
        return mapper.Map<List<CustomerReadDTO>>(unitOfWork.CustomerRepo.GetAllCustomersWithAddresses());
    }

    public CustomerReadDTO GetCustomerWithAddressesById(int id)
    {
        return mapper.Map<CustomerReadDTO>(unitOfWork.CustomerRepo.GetCustomerWithAddresses(id));
    }
    public List<CustomerReadDTO> GetAllCustomers()
    {
        return mapper.Map<List<CustomerReadDTO>>(unitOfWork.CustomerRepo.GetAll());
    }
    public CustomerReadDTO GetCustomerById(int id)
    {
        return mapper.Map<CustomerReadDTO>(unitOfWork.CustomerRepo.GetById(id));
    }
    public CustomerReadDTO AddCustomer(CustomerWriteDto Customer)
    {
        Customer.Code = Guid.NewGuid();
        var dbCustomer = mapper.Map<Customer>(Customer);
        unitOfWork.CustomerRepo.Add(dbCustomer);
        unitOfWork.SaveChanges();
        return mapper.Map<CustomerReadDTO>(dbCustomer);
    }
    public bool DeleteCustomer(int id)
    {
        var dbCustomer = unitOfWork.CustomerRepo.GetById(id);
        if (dbCustomer != null)
        {
            unitOfWork.CustomerRepo.Delete(dbCustomer);
            unitOfWork.SaveChanges();
            return true;
        }
        return false;
    }
    public bool UpdateCustomer(CustomerWriteDto Customer)
    {
        var dbCustomer = unitOfWork.CustomerRepo.GetById(Customer.Id);
        if (dbCustomer != null)
        {
            dbCustomer.FirstName = Customer.FirstName;
            dbCustomer.LastName = Customer.LastName;
            dbCustomer.Email = Customer.Email;
            dbCustomer.Phone = Customer.Phone;
            unitOfWork.SaveChanges();
            return true;
        }
        return false;
    }
}
