using System.Collections.Generic;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> AllSuppliers();

        Supplier GetById(int Id);

        void Add(Supplier supplier);

        void Update(Supplier supplier);

        bool Remove(int Id);
    }
}