using System.Collections.Generic;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public interface ISalesOrderRepository
    {
        IEnumerable<SalesOrder> AllSalesOrders();

        SalesOrder GetById(int Id);

        void Add(SalesOrder salesOrder);

        void Update(SalesOrder salesOrder);

        bool Remove(int Id);
    }
}