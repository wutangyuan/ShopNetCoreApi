using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyfirstCoreApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyfirstCoreApi.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]/[action]")]
    public class productController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product>GetProducts()
        {
            List<Product> list = new List<Product>();

            for (int i = 0; i < 9; i++)
            {
                Product product = new Product();
                product.id = i + 1;
                product.price = (5000 + i).ToString();
                product.productimagename = "static/imagesource/b.jpg";
                product.productname = $"华为{i}";
                list.Add(product);
            }
            return list;
        }

        [HttpGet]
        public Product GetProductById(int id)
        {
            Product product = new Product();
            product.id = id;
            product.price = (6000 + id).ToString();
            product.productimagename = "/static/imagesource/b.jpg";
            product.productname = $"华为{id}";
            return product;
        }

        [HttpGet]
        public int Addcart(int ProductId,int count)
        {
         
            return 1;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
         

        }
    }
}
