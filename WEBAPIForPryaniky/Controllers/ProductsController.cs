using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiForPryaniky.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController
    {
        [HttpGet("list")]
        public IEnumerable<Product> Get()
        {
            return Product.AllProducts.Values;
        }
    }
}
