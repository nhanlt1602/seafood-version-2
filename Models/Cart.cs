using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seafood_version_2.Models
{
    public class CartItem
    {
        public Product shopping_product { get; set; }
        public int shopping_quantity { get; set; }

    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();

        public List<CartItem> Items
        {
            get { return items; }
        }
    }
}
