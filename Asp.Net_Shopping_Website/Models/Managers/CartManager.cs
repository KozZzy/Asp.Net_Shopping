using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGenelTekrar4.Models.Managers
{
    public class CartManager
    {
        Dictionary<int, Cart> _carts = new Dictionary<int, Cart>();

        public List<Cart> Carts => _carts.Values.ToList();
        public decimal TotalPrice => _carts.Sum(x => x.Value.SubPrice);

        public void Add(Cart cart)
        {
            if (_carts.ContainsKey(cart.ID))
            {
                _carts[cart.ID].Amount++;
            }
            else
            {
                _carts.Add(cart.ID, cart);
            }
        }

        public void Delete(int id)
        {
            if (_carts[id].Amount > 1)
            {
                _carts[id].Amount--;
            }
            else
            {
                _carts.Remove(id);
            }
        }

        public void Update(params short[] amounts)
        {
            for (int i = 0; i < amounts.Length; i++)
            {
                _carts.ElementAt(i).Value.Amount = amounts[i];
            }
        }
    }
}