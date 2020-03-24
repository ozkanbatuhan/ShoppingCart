using System;
using System.Collections.Generic;
using Trendyol___Shopping_Cart.Models;

namespace Trendyol___Shopping_Cart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------- Hello World --------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();


            /* ------------------------------------------------- Generate Categories ---------------------------------------------- */

            Category fruit = new Category() { Title = "Fruit" };
            Category beverage = new Category() { Title = "Beverage" };
            Category stationery = new Category() { Title = "Stationery" };

            /* ******************************************************************************************************************** */



            /* -------------------------------------------------- Generate Products ----------------------------------------------- */

            Product apple = new Product() { Title = "Apple", Price = 3.0, Category = fruit };
            Product banana = new Product() { Title = "Almond", Price = 5.0, Category = fruit };
            Product ananas = new Product() { Title = "Ananas", Price = 10.0, Category = fruit };
            Product water = new Product() { Title = "Water", Price = 1.0, Category = beverage };
            Product soda = new Product() { Title = "Soda", Price = 3.0, Category = beverage };
            Product milk = new Product() { Title = "Milk", Price = 5.0, Category = beverage };
            Product fruitjuice = new Product() { Title = "Fruit Juice", Price = 3.0, Category = beverage };
            Product notebook = new Product() { Title = "Notebook", Price = 30.0, Category = stationery };
            Product pencil = new Product() { Title = "Pencil", Price = 10.0, Category = stationery };
            Product pen = new Product() { Title = "Pen", Price = 15.0, Category = stationery };

            /* ******************************************************************************************************************** */



            /* ------------------------------------------------- Generate Campaigns ----------------------------------------------- */

            List<Campaign> campaigns = new List<Campaign>();
            
            campaigns.Add(new CampaignRate() { Category = fruit, Discount = 10.0, MinimumItem = 3 });
            campaigns.Add(new CampaignRate() { Category = fruit, Discount = 20.0, MinimumItem = 5 });
            campaigns.Add(new CampaignAmount() { Category = fruit, Discount = 3.0, MinimumItem = 5 });
            campaigns.Add(new CampaignRate() { Category = beverage, Discount = 20.0, MinimumItem = 8 });
            campaigns.Add(new CampaignRate() { Category = beverage, Discount = 30.0, MinimumItem = 10 });
            campaigns.Add(new CampaignAmount() { Category = beverage, Discount = 5.0, MinimumItem = 5 });
            campaigns.Add(new CampaignRate() { Category = stationery, Discount = 20.0, MinimumItem = 2 });
            campaigns.Add(new CampaignRate() { Category = stationery, Discount = 40.0, MinimumItem = 5 });

            /* ******************************************************************************************************************** */



            /* ------------------------------------------------ Add Products to Cart ---------------------------------------------- */

            ShoppingCart cart = new ShoppingCart();
                        
            cart.addItem(apple, 5);
            cart.addItem(banana, 4);
            cart.addItem(ananas, 2);
            cart.addItem(water, 3);
            cart.addItem(soda, 2);
            cart.addItem(milk, 2);
            cart.addItem(fruitjuice, 1);
            cart.addItem(notebook, 1);
            cart.addItem(pencil, 2);
            cart.addItem(pen, 1);

            /* ******************************************************************************************************************** */

            


            /* --------------------------------------------------- Apply Discounts ------------------------------------------------ */

            cart.applyDiscounts(campaigns);

            /* ******************************************************************************************************************** */



            /* ---------------------------------------------------- Apply Coupon -------------------------------------------------- */

            cart.applyCoupon(new CouponAmount() { Discount = 10.0, MinimumAmount = 80.0 });

            /* ******************************************************************************************************************** */



            /* ----------------------------------------------- Calculate Delivery Cost -------------------------------------------- */

            double deliveryCost = new DeliveryCostCalculator() { costPerDelivery = 0.5, costPerProduct = 0.5, fixedCost = 2.99 }.deliveryCostCalculator(cart);

            /* ******************************************************************************************************************** */



            /* -------------------------------------------------- Print Everything ------------------------------------------------ */

            cart.print();

            /* ******************************************************************************************************************** */


            Console.WriteLine("-------------------------------------------- Bye Bye World --------------------------------------------");
            Console.WriteLine();
        }
    }
}