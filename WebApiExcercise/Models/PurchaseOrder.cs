using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiExcercise.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; } 

        public DateTime PurchaseDate{ get; set; }

        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

        public double TotalAmount { get; set; }
    }

    public class PurchaseOrderLine
    {
        public int Id { get; set; }  

        public int Quantity { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }

    }

}