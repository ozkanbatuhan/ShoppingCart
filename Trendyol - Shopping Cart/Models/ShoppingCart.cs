using System;
using System.Collections.Generic;

namespace Trendyol___Shopping_Cart.Models
{
    public class ShoppingCart
    {
        public double TotalAmount { get; set; }

        public double TotalAmountAfterDiscounts { get; set; }

        public double CampaignDiscount { get; set; }

        public double CouponDiscount { get; set; }

        public double DeliveryCost { get; set; }
                
        public List<Category> Categories { get; set; }


        public ShoppingCart()
        {
            Categories = new List<Category>();
        }


        public double getTotalAmountAfterDiscounts()
        {
            return this.TotalAmountAfterDiscounts;
        }

        public double getCouponDiscounts()
        {
            return this.CouponDiscount;
        }

        public double getCampaignDiscounts()
        {
            return this.CampaignDiscount;
        }

        public double getDeliveryCost()
        {
            return this.DeliveryCost;
        }

        
        public void addItem(Product product, int quantity) // Add Product into the Shopping Cart
        {
            product.Quantity = quantity;

            foreach (var category in this.Categories)
            {
                if (category.Title == product.Category.Title)
                {
                    category.Products.Add(product);
                    return;
                }
            }
            Category newCategory = new Category() { Title = product.Category.Title };
            newCategory.Products.Add(product);
            this.Categories.Add(newCategory);
        }

        public void applyCoupon(Coupon coupon) // Apply the Coupon on Shopping Cart
        {
            this.TotalAmountAfterDiscounts = this.TotalAmount - this.CampaignDiscount;

            if (TotalAmountAfterDiscounts < coupon.MinimumAmount)
            {
                this.CouponDiscount = 0.0;
                return;
            }
            this.CouponDiscount = coupon.getDiscount(TotalAmountAfterDiscounts);
            this.TotalAmountAfterDiscounts = Math.Round(this.TotalAmountAfterDiscounts -= CouponDiscount, 2);
        }

        public void applyDiscounts(List<Campaign> campaigns) // Apply the maximum discount of all Campaign types
        {
            this.TotalAmount = 0.0; this.CampaignDiscount = 0.0;

            foreach (var category in this.Categories)
            {
                double TotalProductAmount = 0.0, MaxDiscountedProductCost = 0.0, DiscountAmount = 0.0;
                int TotalProductQuantity = 0;

                foreach (var product in category.Products) // Total Amount in the Shopping Cart
                {
                    TotalProductAmount += (product.Price * product.Quantity);
                    TotalProductQuantity += product.Quantity;
                }
                MaxDiscountedProductCost = TotalProductAmount;

                foreach (var campaign in campaigns) // Check all Campaigns and find the most discounted one
                {
                    if (campaign.Category.Title != category.Title)
                        continue;

                    if (TotalProductQuantity <= campaign.MinimumItem)
                        continue;

                    double DiscountedPrice = 0.0;

                    DiscountAmount = campaign.getDiscount(TotalProductAmount);
                    DiscountedPrice = TotalProductAmount - DiscountAmount;

                    if (DiscountedPrice < MaxDiscountedProductCost)
                        MaxDiscountedProductCost = DiscountedPrice;
                }
                this.CampaignDiscount += (TotalProductAmount - MaxDiscountedProductCost);
                this.TotalAmount += TotalProductAmount;
            }
        }

        public void print()
        {
            foreach (var category in this.Categories)
            {
                Console.WriteLine("  Category Name: " + category.Title);
                Console.WriteLine();

                double categoryTotalPrice = 0.0;
                foreach (var product in category.Products)
                {
                    double ProductTotalPrice = product.Quantity * product.Price;
                    Console.WriteLine("    Product Name: " + product.Title + ",   Quantity: " + product.Quantity + ",   Unit Price: " + product.Price + ",   Total Price: " + ProductTotalPrice + "TL");
                    categoryTotalPrice += ProductTotalPrice;
                }
                Console.WriteLine(" + _________________________________________________________________________________________");
                Console.WriteLine("    " + category.Title + " Category Total Price: " + categoryTotalPrice + "TL");
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("    Sub Total: " + this.TotalAmount + "TL");
            Console.WriteLine("    Campaign Discount: " + this.CampaignDiscount + "TL");
            Console.WriteLine(" - _________________________________________________________________________________________");
            Console.WriteLine("    Total Price After Campaign Discount: " + (this.TotalAmount - this.CampaignDiscount) + "TL");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("    Sub Total: " + (this.TotalAmount - this.CampaignDiscount) + "TL");
            Console.WriteLine("    Coupon Discount: " + this.CouponDiscount + "TL");
            Console.WriteLine(" - _________________________________________________________________________________________");
            Console.WriteLine("    Total Price After Coupon Discount: " + this.TotalAmountAfterDiscounts + "TL");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("    Sub Total: " + this.TotalAmountAfterDiscounts + "TL");
            Console.WriteLine("    Delivery Cost: " + this.DeliveryCost + "TL");
            Console.WriteLine(" + _________________________________________________________________________________________");
            Console.WriteLine("    Finally TOTAL COST: " + (this.TotalAmountAfterDiscounts + this.DeliveryCost) + "TL");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}