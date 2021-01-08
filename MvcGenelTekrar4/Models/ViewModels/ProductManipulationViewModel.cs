using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGenelTekrar4.Models.ViewModels
{
    public class ProductManipulationViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public string ButtonText { get; set; }
    }
}