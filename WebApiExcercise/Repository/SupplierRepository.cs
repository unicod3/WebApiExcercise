using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public class SupplierRepository : ISupplierRepository
    { 
        public void Add(Supplier supplier)
        {
            TestDataHelper.GetMySuppliers.Add(supplier);
        }

        public IEnumerable<Supplier> AllSuppliers()
        {
            return TestDataHelper.GetMySuppliers;
        }

        public Supplier GetById(int Id)
        {
            var supplier = (from s in TestDataHelper.GetMySuppliers where s.Id == Id select s).SingleOrDefault();
            return supplier;
        }

        public bool Remove(int Id)
        {
            var supplier = GetById(Id);
            if (supplier != null)
                TestDataHelper.GetMySuppliers.Remove(supplier);

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