using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private List<SalesOrder> _salesOrderTable;
        private List<User> _userTable;
        private List<Product> _productTable;
        public SalesOrderRepository()
        {
            _salesOrderTable = TestDataHelper.GetMySalesOrders();
            _userTable = TestDataHelper.GetMyUsers();
            _productTable = TestDataHelper.GetMyProducts();
        }

        public void Add(SalesOrder salesOrder)
        {
            salesOrder.Id = _salesOrderTable.LastOrDefault().Id + 1;
            //get the product objects
            foreach (var SOLine in salesOrder.SalesOrderLine)
                SOLine.Product = _productTable.Where(x => x.Id == SOLine.ProductId).SingleOrDefault();

            //get the user object
            salesOrder.User = _userTable.Where(x => x.Id == salesOrder.UserId).SingleOrDefault();

            //calculate total amount of sales order
            salesOrder.TotalAmount = CalculateTotalAmount(salesOrder);
            _salesOrderTable.Add(salesOrder);
        }

        public IEnumerable<SalesOrder> AllSalesOrders()
        {
            return _salesOrderTable;
        }

        public SalesOrder GetById(int Id)
        {
            var salesOrder = (from s in _salesOrderTable where s.Id == Id select s).SingleOrDefault();
            return salesOrder;
        }

        public bool Remove(int Id)
        {
            var salesOrder = GetById(Id);
            if (salesOrder != null)
                _salesOrderTable.Remove(salesOrder);

            return GetById(Id) == null;
        }

        public void Update(SalesOrder salesOrder)
        {
            //get the product objects
            foreach (var SOLine in salesOrder.SalesOrderLine)
                SOLine.Product = _productTable.Where(x => x.Id == SOLine.ProductId).SingleOrDefault();

            //get the user object
            salesOrder.User = _userTable.Where(x => x.Id == salesOrder.UserId).SingleOrDefault();

            var oldSalesOrder = GetById(salesOrder.Id);
            oldSalesOrder.SalesDate = salesOrder.SalesDate;
            oldSalesOrder.SalesOrderLine = salesOrder.SalesOrderLine;
            oldSalesOrder.UserId = salesOrder.UserId;
            oldSalesOrder.User = salesOrder.User;
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