using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private List<SalesOrder> _testTable;
        public SalesOrderRepository()
        {
            _testTable = TestDataHelper.GetMySalesOrders();
        }

        public void Add(SalesOrder salesOrder)
        {
            //calculate total amount of sales order
            salesOrder.TotalAmount = CalculateTotalAmount(salesOrder);
            _testTable.Add(salesOrder);
        }

        public IEnumerable<SalesOrder> AllSalesOrders()
        {
            return _testTable;
        }

        public SalesOrder GetById(int Id)
        {
            var salesOrder = (from s in _testTable where s.Id == Id select s).SingleOrDefault();
            return salesOrder;
        }

        public bool Remove(int Id)
        {
            var salesOrder = GetById(Id);
            if (salesOrder != null)
                _testTable.Remove(salesOrder);

            return GetById(Id) == null;
        }

        public void Update(SalesOrder salesOrder)
        {
            //get the product objects
            foreach (var SOLine in salesOrder.SalesOrderLine)
                SOLine.Product = TestDataHelper.GetMyProducts().Where(x => x.Id == SOLine.ProductId).SingleOrDefault();

            var oldSalesOrder = GetById(salesOrder.Id);
            oldSalesOrder.SalesDate = salesOrder.SalesDate;
            oldSalesOrder.SalesOrderLine = salesOrder.SalesOrderLine;
            oldSalesOrder.UserId = salesOrder.UserId;
            oldSalesOrder.User = TestDataHelper.GetMyUsers().Where(x => x.Id == salesOrder.UserId).SingleOrDefault();
            oldSalesOrder.TotalAmount = CalculateTotalAmount(salesOrder);
        }

        private double CalculateTotalAmount(SalesOrder salesOrder)
        {
            double TotalAmount = 0;
            var salesOrderLines = from p in salesOrder.SalesOrderLine select p;
            foreach (var salesOrderLine in salesOrderLines)
            {
                TotalAmount += (salesOrderLine.Product.Price * salesOrderLine.Quantity);
            }
            return TotalAmount;
        }
    }
}