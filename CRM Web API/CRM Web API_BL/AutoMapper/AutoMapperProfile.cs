using AutoMapper;
using CRM_Web_API_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
        CreateMap<Product, ProductReadDTO>();
        CreateMap<Product, ProductWriteDTO>();

        CreateMap<ProductWriteDTO, Product>();
        CreateMap<ProductReadDTO, Product>();

        CreateMap<Customer, CustomerReadDTO>();

        CreateMap<Customer, CustomerChildReadDTO>();

        CreateMap<CustomerWriteDto, Customer>();

        CreateMap<CustomerAddressChildReadDTO, CustomerAddress>();

        CreateMap<CustomerAddress, CustomerAddressChildReadDTO>();

        CreateMap<CustomerAddress, CustomerAddressReadDTO>();

        CreateMap<CustomerAddressWriteDTO, CustomerAddress>();
    }
}
