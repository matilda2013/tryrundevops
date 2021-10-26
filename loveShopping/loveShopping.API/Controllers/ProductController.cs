using loveShopping.API.Data;
using loveShopping.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace loveShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController( ILogger<ProductController> logger, ProductContext context)
        {
             _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        //[HttpGet]
        //public async Task<IEnumerable<Product>> Get()
        //{
        //    var rand = new Random();
        //    return Enumerable.Range(1, 7).Select(i => new Product
        //    {
        //        Name = "Ponk"
        //    }).ToArray();
        //}

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            //return ProductContext.Products;
            return await _context
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        }

    }
}
