using System.Collections.Generic;

namespace Trendyol___Shopping_Cart.Models
{
    public class Category
    {
        public string Title { get; set; }

        public List<Product> Products { get; set; }

        
        public Category()
        {
            Products = new List<Product>();
        }
    }
}
