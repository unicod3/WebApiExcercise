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
    public class PurchaseOrderController : ApiController
    {
        private static readonly IPurchaseOrderRepository _purchaseOrderRepository = new PurchaseOrderRepository();


        public IEnumerable<PurchaseOrder> Get()
        {
            var purchaseOrders = _purchaseOrderRepository.AllPurchaseOrders();
            return purchaseOrders;
        }

        [HttpGet]
        public IHttpActionResult Get(string Id)
        {
            var purchaseOrder = _purchaseOrderRepository.GetById(Convert.ToInt32(Id));
            if (purchaseOrder == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No purchase order with ID = {0}", Id)),
                    ReasonPhrase = "Purchase Order ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return Ok(purchaseOrder);
        }

        [HttpPost]
        public void Post(PurchaseOrder purchaseOrder)
        {
            _purchaseOrderRepository.Add(purchaseOrder);
        }

        [HttpPut]
        public void Put(PurchaseOrder purchaseOrder)
        {
            _purchaseOrderRepository.Update(purchaseOrder);
        }


        public void Delete(string Id)
        {
            if (!_purchaseOrderRepository.Remove(Convert.ToInt32(Id)))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No purchase order with ID = {0}", Id)),
                    ReasonPhrase = "Purchase Order ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}
