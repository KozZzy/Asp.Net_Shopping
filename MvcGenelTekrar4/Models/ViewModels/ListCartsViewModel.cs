using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGenelTekrar4.Models.ViewModels
{
    public class ListCartsViewModel
    {
        public List<Cart> Carts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}