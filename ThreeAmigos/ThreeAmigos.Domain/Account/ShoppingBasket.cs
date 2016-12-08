using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.Domain.Account
{
    public class ShoppingBasket
    {
        public int Id { get; set; }

        public IEnumerable<BasketItem> Items { get; set; }

        public ShoppingBasket()
        {
            Items = new List<BasketItem>();
        }
    }
}
