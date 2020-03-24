namespace Trendyol___Shopping_Cart.Models
{
    public abstract class Campaign
    {
        public double Discount { get; set; }

        public int MinimumItem { get; set; }

        public Category Category { get; set; }


        public abstract double getDiscount(double TotalAmount);
    }

    public class CampaignRate : Campaign
    {
        public override double getDiscount(double TotalAmount)
        {
            return TotalAmount * Discount / 100;
        }
    }

    public class CampaignAmount : Campaign
    {
        public override double getDiscount(double TotalAmount)
        {
            return Discount;
        }
    }
}
