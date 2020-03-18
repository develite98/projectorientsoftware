using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Models
{
    public class Cart
    {
            public Cart()
            {
                Products = new HashSet<Products>();
            }

            public int cartID { get; set; }

            public decimal totalPrice { get; set; }

            public int userID { get; set; }

            public ICollection<Products> Products { get; set; }
    }
}
