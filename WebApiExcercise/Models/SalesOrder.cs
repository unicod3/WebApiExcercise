using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiExcercise.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }

        public DateTime SalesDate { get; set; }

        public virtual ICollection<SalesOrderLine> SalesOrderLine { get; set; }

        public double TotalAmount { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }

    }

    public class SalesOrderLine
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}