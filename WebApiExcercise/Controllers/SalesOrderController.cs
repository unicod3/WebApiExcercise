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
    public class SalesOrderController : ApiController
    {
        private static readonly ISalesOrderRepository _salesOrderRepository = new SalesOrderRepository();


        public IEnumerable<SalesOrder> Get()
        {
            var salesOrders = _salesOrderRepository.AllSalesOrders();
            return salesOrders;
        }

        [HttpGet]
        public IHttpActionResult Get(string Id)
        {
            var salesOrder = _salesOrderRepository.GetById(Convert.ToInt32(Id));
            if (salesOrder == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No sales order with ID = {0}", Id)),
                    ReasonPhrase = "Sales Order ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return Ok(salesOrder);
        }

        [HttpPost]
        public void Post(SalesOrder salesOrder)
        {
            _salesOrderRepository.Add(salesOrder);
        }

        [HttpPut]
        public void Put(SalesOrder salesOrder)
        {
            _salesOrderRepository.Update(salesOrder);
        }


        public void Delete(string Id)
        {
            if (!_salesOrderRepository.Remove(Convert.ToInt32(Id)))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No sales order with ID = {0}", Id)),
                    ReasonPhrase = "Sales Order ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}
