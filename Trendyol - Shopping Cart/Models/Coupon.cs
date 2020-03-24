namespace Trendyol___Shopping_Cart.Models
{
    public abstract class Coupon
    {
        public double Discount { get; set; }

        public double MinimumAmount { get; set; }


        public abstract double getDiscount(double TotalAmountAfterDiscounts);
    }

    public class CouponRate : Coupon
    {
        public override double getDiscount(double TotalAmountAfterDiscounts)
        {
            return TotalAmountAfterDiscounts * Discount / 100;
        }
    }

    public class CouponAmount : Coupon
    {
        public override double getDiscount(double TotalAmountAfterDiscounts)
        {
            return Discount;
        }
    }
}
