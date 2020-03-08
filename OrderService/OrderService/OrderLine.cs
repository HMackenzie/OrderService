using System.Collections.Generic;
using System.Linq;

namespace OrderService
{
    public class OrderLine
    {
        public OrderLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            QualifyingDiscounts = QualifyDiscounts(product, quantity).ToList();
            LineTotalPrice = CalculateLineTotal();
        }
        public Product Product { get; }

        public int Quantity { get; }

        public float LineTotalPrice { get; set; }

        public List<Discount> QualifyingDiscounts { get; set; }

        private float CalculateLineTotal()
        {
            if (!QualifyingDiscounts.Any())
            {
                return Product.Price * Quantity;
            }

            var bestDiscount = QualifyingDiscounts.Min(x => x.Modifier);

            return Product.Price * Quantity * bestDiscount;
        }

        public IEnumerable<Discount> QualifyDiscounts(Product product, int quantity)
        {
            var discounts = new List<Discount>();

            discounts.Add(new Discount
            {
                Type = DiscountType.TenPercentOff,
                Condition = product.Price >= 1000 && quantity >= 5,
                Modifier = 0.9f
            });

            discounts.Add(new Discount
            {
                Type = DiscountType.TenPercentOff,
                Condition = product.Price >= 2000 && quantity >= 3,
                Modifier = 0.8f
            });

            // Add any further discounts here

            return discounts.Where(discount => discount.Condition);
        }
    }
}