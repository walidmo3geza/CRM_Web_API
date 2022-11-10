using CRM_Web_API_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager productManager;
        public ProductsController(IProductManager _productManager)
        {
            productManager = _productManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDTO>> GetAllproducts()
        {
            return productManager.GetAllProducts();
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<ProductReadDTO> GetproductDyId(int id)
        {
            var product = productManager.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        // POST: api/products
        [HttpPost]
        public ActionResult<ProductReadDTO> Addproduct(ProductWriteDTO product)
        {
            var productRead = productManager.AddProduct(product);
            return CreatedAtAction("GetproductDyId", new { id = productRead.Id }, productRead);
        }
        // PUT: api/products/5
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Editproduct(ProductWriteDTO product)
        {
            var result = productManager.UpdateProduct(product);
            if (!result)
                return NotFound();

            return NoContent();
        }
        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public IActionResult Deleteproduct(int id)
        {
            var result = productManager.DeleteProduct(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
