using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_API_BL;
public interface IProductManager
{
    List<ProductReadDTO> GetAllProducts();
    ProductReadDTO GetProductById(int id);
    ProductReadDTO AddProduct(ProductWriteDTO product);
    bool UpdateProduct(ProductWriteDTO product);
    bool DeleteProduct(int id);
}
