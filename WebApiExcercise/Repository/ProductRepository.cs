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
        public ProductRepository() {
            _productTable = TestDataHelper.GetMyProducts();
        }

        public void Add(Product product)
        {
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
            oldProduct.SupplierId = product.SupplierId;
        }
    }
}