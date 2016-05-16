using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public class ProductRepository : IProductRepository
    {

        private List<Product> _productTable;
        private List<Supplier> _supplierTable;

        public ProductRepository() {
            _productTable = TestDataHelper.GetMyProducts();
            _supplierTable = TestDataHelper.GetMySuppliers();
        }

        public void Add(Product product)
        {
            product.Id = _productTable.LastOrDefault().Id + 1;
            product.SupplierId = product.Supplier.Id;
            product.Supplier = _supplierTable.Where(x => x.Id == product.Supplier.Id).SingleOrDefault();
            _productTable.Add(product);
        }

        public IEnumerable<Product> AllProducts()
        {
            return _productTable;
        }

        public Product GetById(int Id)
        {
            var product = (from s in _productTable where s.Id == Id select s).SingleOrDefault();
            return product;
        }

        public bool Remove(int Id)
        {
            var product = GetById(Id);
            if (product != null)
                _productTable.Remove(product);

            return GetById(Id) == null;
        }

        public void Update(Product product)
        {
            var oldProduct = GetById(product.Id);
            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            oldProduct.SupplierId = product.Supplier.Id;
            oldProduct.Supplier = _supplierTable.Where(x => x.Id == product.Supplier.Id).SingleOrDefault();
        }
    }
}