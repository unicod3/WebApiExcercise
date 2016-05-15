using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private List<Supplier> _testTable;

        public SupplierRepository() {
           _testTable  = TestDataHelper.GetMySuppliers();
        }
        public void Add(Supplier supplier)
        {
            _testTable.Add(supplier);
        }

        public IEnumerable<Supplier> AllSuppliers()
        {
            return _testTable;
        }

        public Supplier GetById(int Id)
        {
            var supplier = (from s in _testTable where s.Id == Id select s).SingleOrDefault();
            return supplier;
        }

        public bool Remove(int Id)
        {
            var supplier = GetById(Id);
            if (supplier != null)
                _testTable.Remove(supplier);

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