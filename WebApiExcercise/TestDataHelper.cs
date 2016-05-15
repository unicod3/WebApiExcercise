using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise
{
    public static class TestDataHelper
    {

        /// <summary>
        /// Supplier List
        /// </summary>
        private static Supplier Supplier1 = new Supplier { Id = 1, Name = "Nestle", PaymentDay = DateTime.Now.AddMonths(1), Products = Chocolate };
        private static Supplier Supplier2 = new Supplier { Id = 2, Name = "Lipton", PaymentDay = DateTime.Now.AddMonths(2), Products = Tea };

        /// <summary>
        /// User List
        /// </summary>
        private static User User1 = new User { Id = 1, Name = "John Doe", Email = "johndoe@doe.com" };
        private static User User2 = new User { Id = 2,  Name = "Jane Doe", Email = "janedoe@doe.com" };

        /// <summary>
        /// List Of Products
        /// </summary> 
        private static Product P1 = new Product { Id = 1, Name = "Aero", Price = 5, SupplierId = 1, Supplier = Supplier1 };
        private static Product P2 = new Product { Id = 2, Name = "Aero Caramel", Price = 10, SupplierId = 1, Supplier = Supplier1 };
        private static Product P3 = new Product { Id = 3, Name = "Aero Mint", Price = 15, SupplierId = 1, Supplier = Supplier1 };
        private static Product P4 = new Product { Id = 4, Name = "Blueberry", Price = 5, SupplierId = 2, Supplier = Supplier2 };
        private static Product P5 = new Product { Id = 5, Name = "Chai", Price = 10, SupplierId = 2, Supplier = Supplier2 };
        private static Product P6 = new Product { Id = 6, Name = "Cinnamon", Price = 15, SupplierId = 2, Supplier = Supplier2 };

        /// <summary>
        /// Chocolate List
        /// </summary>
        private static List<Product> Chocolate = new List<Product>() { P1, P2, P3 };

        /// <summary>
        /// Tea List
        /// </summary>
        private static List<Product> Tea = new List<Product>() { P4, P5, P6 };


        /// <summary>
        /// List Of Purchase Order Line
        /// </summary>
        private static List<PurchaseOrderLine> PO1 = new List<PurchaseOrderLine>()
        {
            new PurchaseOrderLine { Id = 1, ProductId = 1, Product = P1, Quantity = 5 },
            new PurchaseOrderLine { Id = 2, ProductId = 2, Product = P2, Quantity = 5 },
            new PurchaseOrderLine { Id = 3, ProductId = 3, Product = P3, Quantity = 5 }
        };
        private static List<PurchaseOrderLine> PO2 = new List<PurchaseOrderLine>()
        {
            new PurchaseOrderLine { Id = 1, ProductId = 4, Product = P4, Quantity = 5 },
            new PurchaseOrderLine { Id = 2, ProductId = 5, Product = P5, Quantity = 5 },
            new PurchaseOrderLine { Id = 3, ProductId = 6, Product = P6, Quantity = 5 }
        }; 

        /// <summary>
        /// List Of Sales Order Line
        /// </summary>
        private static List<SalesOrderLine> SO1 = new List<SalesOrderLine>()
        {
            new SalesOrderLine { Id = 1, ProductId = 1, Product = P1, Quantity = 2 },
            new SalesOrderLine { Id = 2, ProductId = 2, Product = P2, Quantity = 2 },
            new SalesOrderLine { Id = 3, ProductId = 3, Product = P3, Quantity = 2 }
        };
        private static List<SalesOrderLine> SO2 = new List<SalesOrderLine>()
        {
            new SalesOrderLine { Id = 1, ProductId = 4, Product = P4, Quantity = 5 },
            new SalesOrderLine { Id = 2, ProductId = 5, Product = P5, Quantity = 5 },
            new SalesOrderLine { Id = 3, ProductId = 6, Product = P6, Quantity = 5 }
        };


        /// <summary>
        /// Get List Of Suppliers
        /// </summary>
        /// <returns>List<Supplier></returns>
        public static List<Supplier> GetMySuppliers()
        {
            return new List<Supplier>() { Supplier1, Supplier2 };
        }

        /// <summary>
        /// Get List Of Products
        /// </summary>
        /// <returns>List<Product></returns>
        public static List<Product> GetMyProducts() {
            return new List<Product>() { P1, P2, P3, P4, P5, P6 }; 
        }

        /// <summary>
        /// Get List Of Users
        /// </summary>
        /// <returns>List<User></returns>
        public static List<User> GetMyUsers()
        {
            return new List<User>() { User1, User2 };
        }

        /// <summary>
        /// Get List Of PurchaseOrders
        /// </summary>
        /// <returns>List<PurchaseOrder></returns>
        public static List<PurchaseOrder> GetMyPurchaseOrders()
        {
            return new List<PurchaseOrder>() {
                 new PurchaseOrder { Id = 1,  TotalAmount = 150, PurchaseDate = DateTime.Now.AddMonths(-1), PurchaseOrderLine = PO1 },
                 new PurchaseOrder { Id = 2,  TotalAmount = 150, PurchaseDate = DateTime.Now.AddMonths(-2), PurchaseOrderLine = PO2 }
            };
        }

        /// <summary>
        /// Get List Of SalesOrders
        /// </summary>
        /// <returns>List<SalesOrder></returns>
        public static List<SalesOrder> GetMySalesOrders()
        {
            return new List<SalesOrder>() {
                 new SalesOrder { Id = 1,  TotalAmount = 150, SalesDate = DateTime.Now.AddDays(-1), UserId = 1, User = User1, SalesOrderLine = SO2 },
                 new SalesOrder { Id = 2,  TotalAmount = 150, SalesDate = DateTime.Now.AddDays(-2), UserId = 2, User = User2, SalesOrderLine = SO2 }
            };
        }


    }
}