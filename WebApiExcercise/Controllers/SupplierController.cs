using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExcercise.Models;
using WebApiExcercise.Repository;

namespace WebApiExcercise.Controllers
{
    public class SupplierController : ApiController
    {
        private static readonly ISupplierRepository _supplierRepository = new SupplierRepository();
        

        public IEnumerable<Supplier> Get()
        {
            var suppliers = _supplierRepository.AllSuppliers();
            return suppliers;
        }

        [HttpGet]
        public IHttpActionResult Get(string Id)
        { 
            var supplier = _supplierRepository.GetById(Convert.ToInt32(Id));
            if (supplier == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No supplier with ID = {0}", Id)),
                    ReasonPhrase = "Supplier ID Not Found"
                };
                throw new System.Web.Http.HttpResponseException(resp); 
            }
            return Ok(supplier);
        }

        [HttpPost]
        public void Post(Supplier supplier) {
            _supplierRepository.Add(supplier);
        }

        
        public void Delete(string Id)
        {
            if (!_supplierRepository.Remove(Convert.ToInt32(Id)))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No supplier with ID = {0}", Id)),
                    ReasonPhrase = "Supplier ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}
