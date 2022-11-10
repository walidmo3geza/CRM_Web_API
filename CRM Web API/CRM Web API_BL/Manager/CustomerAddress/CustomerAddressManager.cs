using AutoMapper;
using CRM_Web_API_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;

public class CustomerAddressManager : ICustomerAddressManager
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public CustomerAddressManager(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
    }
    public List<CustomerAddressReadDTO> GetAllCustomerAddresssWithAddresses()
    {
        return mapper.Map<List<CustomerAddressReadDTO>>(unitOfWork.CustomerAddressRepo.GetAllCustomerAddressesWithCustomer());
    }

    public CustomerAddressReadDTO GetCustomerAddressWithAddressesById(int id)
    {
        return mapper.Map<CustomerAddressReadDTO>(unitOfWork.CustomerAddressRepo.GetCustomerAddressWithCustomerByID(id));
    }
    public List<CustomerAddressReadDTO> GetAllCustomerAddresss()
    {
        return mapper.Map<List<CustomerAddressReadDTO>>(unitOfWork.CustomerAddressRepo.GetAll());
    }
    public CustomerAddressReadDTO GetCustomerAddressById(int id)
    {
        return mapper.Map<CustomerAddressReadDTO>(unitOfWork.CustomerAddressRepo.GetById(id));
    }
    public CustomerAddressReadDTO AddCustomerAddress(CustomerAddressWriteDTO CustomerAddress)
    {
        var dbCustomerAddress = mapper.Map<CustomerAddress>(CustomerAddress);
        unitOfWork.CustomerAddressRepo.Add(dbCustomerAddress);
        unitOfWork.SaveChanges();
        return mapper.Map<CustomerAddressReadDTO>(dbCustomerAddress);
    }
    public bool DeleteCustomerAddress(int id)
    {
        var dbCustomerAddress = unitOfWork.CustomerAddressRepo.GetById(id);
        if (dbCustomerAddress != null)
        {
            unitOfWork.CustomerAddressRepo.Delete(dbCustomerAddress);
            unitOfWork.SaveChanges();
            return true;
        }
        return false;
    }
    public bool UpdateCustomerAddress(CustomerAddressWriteDTO CustomerAddress)
    {
        var dbCustomerAddress = unitOfWork.CustomerAddressRepo.GetById(CustomerAddress.Id);
        if (dbCustomerAddress != null)
        {
            dbCustomerAddress.AddressLine_1 = CustomerAddress.AddressLine_1;
            dbCustomerAddress.AddressLine_2 = CustomerAddress.AddressLine_2;
            dbCustomerAddress.City = CustomerAddress.City;
            dbCustomerAddress.PostalCode = CustomerAddress.PostalCode;
            dbCustomerAddress.State = CustomerAddress.State;
            dbCustomerAddress.Country = CustomerAddress.Country;
            dbCustomerAddress.ShippingAddressFlag = CustomerAddress.ShippingAddressFlag;
            dbCustomerAddress.BillingAddressFlag = CustomerAddress.BillingAddressFlag;
            unitOfWork.SaveChanges();
            return true;
        }
        return false;
    }
}
