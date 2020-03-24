namespace Trendyol___Shopping_Cart.Models
{
    public class DeliveryCostCalculator
    {
        public double costPerDelivery { get; set; }

        public double costPerProduct { get; set; }

        public double fixedCost { get; set; }


        public double deliveryCostCalculator(ShoppingCart shoppingCart)
        {
            int NumberOfDeliveries = 0, NumberOfProducts = 0;

            foreach (var category in shoppingCart.Categories)
            {
                NumberOfDeliveries++;
                foreach (var product in category.Products)
                    NumberOfProducts++;
            }
            shoppingCart.DeliveryCost = (this.costPerDelivery * NumberOfDeliveries) + (this.costPerProduct * NumberOfProducts) + this.fixedCost;
            return shoppingCart.DeliveryCost;
        }
    }
}
