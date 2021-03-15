using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {

        public ProductsService service { get; set; }

        public ProductController()
        {
            service = new ProductsService();
        }

        [HttpPost("getProducts")]
        public ActionResult<ProductsViewModel> GetProducts(RequestProductsModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(400, "The data request is not valid");

                return service.GetMany(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error to get products: {ex.Message}");
            }
        }

        [HttpGet("getProduct")]
        public ActionResult<Produto> GetProduct(long productId)
        {
            try
            {
                return service.GetOne(productId);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error to get product : {ex.Message}");
            }
        }


        [HttpPost("registerOrUpdateProduct")]
        public ActionResult<Produto> RegisterOrUpdateProduct(Produto product)
        {
            try
            {
                return service.Save(product);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error to register product : {ex.Message}");
            }
        }

        [HttpDelete("deleteProduct")]
        public ActionResult DeleteProduct(long productId)
        {
            try
            {
                service.Delete(productId);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error to delete product: {ex.Message}");
            }
        }

    }
}
