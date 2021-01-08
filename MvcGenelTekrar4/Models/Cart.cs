using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGenelTekrar4.Models
{
    public class Cart
    {
        public Cart()
        {
            Amount = 1;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public short Amount { get; set; }
        public decimal Price { get; set; }
        public decimal SubPrice => Amount * Price;
    }
}