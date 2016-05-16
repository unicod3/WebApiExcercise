using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private List<Supplier> _supplierTable;

        public SupplierRepository() {
           _supplierTable  = TestDataHelper.GetMySuppliers();
        }
        public void Add(Supplier supplier)
        {
            supplier.Id = _supplierTable.LastOrDefault().Id + 1;
            _supplierTable.Add(supplier);
        }

        public IEnumerable<Supplier> AllSuppliers()
        {
            return _supplierTable;
        }

        public Supplier GetById(int Id)
        {
            var supplier = (from s in _supplierTable where s.Id == Id select s).SingleOrDefault();
            return supplier;
        }

        public bool Remove(int Id)
        {
            var supplier = GetById(Id);
            if (supplier != null)
                _supplierTable.Remove(supplier);

            return GetById(Id) == null;
        }

        public void Update(Supplier supplier)
        {
            var oldSupplier = GetById(supplier.Id);
            oldSupplier.Name = supplier.Name;
            oldSupplier.Products = supplier.Products;
        }
    }
}