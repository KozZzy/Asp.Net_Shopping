using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGenelTekrar4.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}