using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace zv_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
            private IProductService _productService;
            public ProductController(IProductService productService)
            {
                _productService = productService;
            }



            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _productService.GetAll());
            }


            [HttpGet("{id}")]
            public async Task<IActionResult> GetByProductId(int id)
            {
                return Ok(await _productService.GetByLogin(id));
            }

        }
    }
}
