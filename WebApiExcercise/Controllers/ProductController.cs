using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExcercise.Models;
using WebApiExcercise.Repository;

namespace WebApiExcercise.Controllers
{
    public class ProductController : ApiController
    {
        private static readonly IProductRepository _productRepository = new ProductRepository();


        public IEnumerable<Product> Get()
        {
            var products = _productRepository.AllProducts();
            return products;
        }

        [HttpGet]
        public IHttpActionResult Get(string Id)
        {
            var product = _productRepository.GetById(Convert.ToInt32(Id));
            if (product == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with ID = {0}", Id)),
                    ReasonPhrase = "Product ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return Ok(product);
        }

        [HttpPost]
        public void Post(Product product)
        {
            _productRepository.Add(product);
        }

        [HttpPut]
        public void Put(Product product)
        {
            _productRepository.Update(product);
        }


        public void Delete(string Id)
        {
            if (!_productRepository.Remove(Convert.ToInt32(Id)))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with ID = {0}", Id)),
                    ReasonPhrase = "Product ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}
