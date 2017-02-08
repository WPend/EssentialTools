namespace EssentialTools.Models
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }

    public class DefaultDiscountHelper : IDiscountHelper
    {
        /*  (Listing 6-19 note) DiscountSize contstructor parameter reworked to pass the discountsize as a constructor parameter
        public decimal DiscountSize { get; set; }
        */
        public decimal discountSize;

        public DefaultDiscountHelper(decimal discountParam)
        {
            discountSize = discountParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (/* reworked (see Listing 6-19 note)<<<<<DiscountSize>>>>>*/discountSize / 100m * totalParam));
        }
    }
}
