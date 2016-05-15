using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private List<PurchaseOrder> _testTable;
        public PurchaseOrderRepository()
        {
            _testTable = TestDataHelper.GetMyPurchaseOrders();
        }

        public void Add(PurchaseOrder purchaseOrder)
        {
            //calculate total amount of purchase order
            purchaseOrder.TotalAmount = CalculateTotalAmount(purchaseOrder);
            _testTable.Add(purchaseOrder);
        }

        public IEnumerable<PurchaseOrder> AllPurchaseOrders()
        {
            return _testTable;
        }

        public PurchaseOrder GetById(int Id)
        {
            var purchaseOrder = (from s in _testTable where s.Id == Id select s).SingleOrDefault();
            return purchaseOrder;
        }

        public bool Remove(int Id)
        {
            var purchaseOrder = GetById(Id);
            if (purchaseOrder != null)
                _testTable.Remove(purchaseOrder);

            return GetById(Id) == null;
        }

        public void Update(PurchaseOrder purchaseOrder)
        {
            //get the product objects
            foreach (var POLine in purchaseOrder.PurchaseOrderLine)
                POLine.Product = TestDataHelper.GetMyProducts().Where(x => x.Id == POLine.ProductId).SingleOrDefault();

            var oldPurchaseOrder = GetById(purchaseOrder.Id);
            oldPurchaseOrder.PurchaseDate = purchaseOrder.PurchaseDate;
            oldPurchaseOrder.PurchaseOrderLine = purchaseOrder.PurchaseOrderLine; 
            oldPurchaseOrder.TotalAmount = CalculateTotalAmount(purchaseOrder);
        }

        private double CalculateTotalAmount(PurchaseOrder purchaseOrder)
        {
            double TotalAmount = 0; 
            var purchaseOrderLines = from p in purchaseOrder.PurchaseOrderLine select p;
            foreach (var purchaseOrderLine in purchaseOrderLines)
            {
                TotalAmount += (purchaseOrderLine.Product.Price * purchaseOrderLine.Quantity);
            }
            return TotalAmount;
        }

    }
}