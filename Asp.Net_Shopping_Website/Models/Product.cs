using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGenelTekrar4.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}