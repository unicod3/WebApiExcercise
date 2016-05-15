using System.Collections.Generic;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts();

        Product GetById(int Id);

        void Add(Product product);

        void Update(Product product);

        bool Remove(int Id);
    }
}