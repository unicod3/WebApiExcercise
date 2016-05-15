using System.Collections.Generic;
using WebApiExcercise.Models;

namespace WebApiExcercise.Repository
{
    public interface IPurchaseOrderRepository
    {
        IEnumerable<PurchaseOrder> AllPurchaseOrders();

        PurchaseOrder GetById(int Id);

        void Add(PurchaseOrder purchaseOrder);

        void Update(PurchaseOrder purchaseOrder);

        bool Remove(int Id);
    }
}