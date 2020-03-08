namespace OrderService
{
    public class OrderLine
    {
        public OrderLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Discount = DetermineDiscount(this);
            LineTotalPrice = CalculateLineTotal();
        }

        public Product Product { get; }

        public int Quantity { get; }

        public float LineTotalPrice { get; set; }

        public Discount Discount { get; set; }

        private float CalculateLineTotal()
        {
            return Product.Price * Quantity * Discount.Modifier;
        }

        private Discount DetermineDiscount(OrderLine orderLine)
        {
            var unmodifiedLineTotal = orderLine.Product.Price * orderLine.Quantity;

            if (unmodifiedLineTotal >= 6000)
            {
                return new Discount(DiscountType.TwentyPercentOff, 0.8f);
            }

            if (unmodifiedLineTotal >= 5000)
            {
                return new Discount(DiscountType.TenPercentOff, 0.9f);
            }

            else return new Discount();
        }

        //check available discounts, apply discount
        //'combinable' on discount
        //list of discounts with thier conditions
    }
}