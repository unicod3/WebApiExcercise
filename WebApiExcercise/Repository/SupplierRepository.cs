using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public class SupplierRepository : ISupplierRepository
    {

        public static List<Product> Chocolate = new List<Product>() {
                new Product { Id = 1, Name="Aero", Price = 5, SupplierId = 1},
                new Product { Id = 2, Name="Aero Caramel", Price = 10, SupplierId = 1 },
                new Product { Id = 3, Name="Aero Mint", Price = 15,SupplierId = 1 }
            };

        public static List<Product> Tea = new List<Product>() {
                new Product { Id = 1, Name="Blueberry", Price = 5, SupplierId = 2 },
                new Product { Id = 2, Name="Chai", Price = 10, SupplierId = 2 },
                new Product { Id = 3, Name="Cinnamon", Price = 15, SupplierId = 2 }
            };

        public static List<Supplier> MySuppliers = new List<Supplier>() {
                 new Supplier { Id = 1,  Name = "Nestle", PaymentDay = DateTime.Now.AddMonths(1), Products = Chocolate },
                 new Supplier { Id = 2,  Name = "Lipton", PaymentDay = DateTime.Now.AddMonths(2), Products = Tea }
            }; 

        public void Add(Supplier supplier)
        {
            MySuppliers.Add(supplier);
        }

        public IEnumerable<Supplier> AllSuppliers()
        {
            return MySuppliers;
        }

        public Supplier GetById(int Id)
        {
            var supplier = (from s in MySuppliers where s.Id == Id select s).SingleOrDefault();
            return supplier;
        }

        public bool Remove(int Id)
        {
            var supplier = GetById(Id);
            if (supplier != null)
                MySuppliers.Remove(supplier);

            return GetById(Id) == null;
        }

        public void Update(Supplier supplier)
        {
            var oldSupplier = GetById(supplier.Id);
            oldSupplier.Name = supplier.Name;
            oldSupplier.PaymentDay = supplier.PaymentDay;
            oldSupplier.Products = supplier.Products;
        }
    }
}