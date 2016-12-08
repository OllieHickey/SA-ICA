using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeAmigos.Domain.Store;

namespace ThreeAmigos.Domain.Account
{
    public class BasketItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public GiftWrappingProduct GiftWrap { get; set; }

        public Product Product { get; set; }
    }
}
