using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> AllSuppliers();

        Supplier GetById(int id);

        void Add(Supplier supplier);

        void Update(Supplier supplier);

        bool Remove(int id);
    }
}