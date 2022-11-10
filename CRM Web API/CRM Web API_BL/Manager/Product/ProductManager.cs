using AutoMapper;
using CRM_Web_API_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;
public class ProductManager : IProductManager
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public ProductManager(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
    }
    public List<ProductReadDTO> GetAllProducts()
    {
        return mapper.Map<List<ProductReadDTO>>(unitOfWork.ProductRepo.GetAll());
    }
    public ProductReadDTO GetProductById(int id)
    {
        return mapper.Map<ProductReadDTO>(unitOfWork.ProductRepo.GetById(id));
    }
    public ProductReadDTO AddProduct(ProductWriteDTO product)
    {
        var dbProduct = mapper.Map<Product>(product);
        unitOfWork.ProductRepo.Add(dbProduct);
        unitOfWork.SaveChanges();
        return mapper.Map<ProductReadDTO>(dbProduct);
    }
    public bool DeleteProduct(int id)
    {
        var dbProduct = unitOfWork.ProductRepo.GetById(id);
        if (dbProduct != null)
        {
            unitOfWork.ProductRepo.Delete(dbProduct);
            unitOfWork.SaveChanges();
            return true;
        }
        return false;
    }
    public bool UpdateProduct(ProductWriteDTO product)
    {
        var dbProduct = unitOfWork.ProductRepo.GetById(product.Id);
        if (dbProduct != null)
        {
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.Name = product.Name;
            unitOfWork.SaveChanges();
            return true;
        }
        return false;
    }
}
