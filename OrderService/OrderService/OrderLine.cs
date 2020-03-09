using System.Collections.Generic;
using System.Linq;

namespace OrderService
{
    /// <summary>
    /// Represents a line of an order.
    /// </summary>
    public class OrderLine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLine"/> class.
        /// </summary>
        /// <param name="product">The product to represent on the line.</param>
        /// <param name="quantity">The quanity of products to be represented on the line.</param>
        public OrderLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            LineTotal = CalculateLineTotal();

            //Establish which discounts are available at the OrderLine level. Additional would be added here.
            AvailableDiscounts.Add(new Discount(DiscountType.TenPercentOff, 0.9f, product.Price >= 1000 && quantity >= 5));
            AvailableDiscounts.Add(new Discount(DiscountType.TwentyPercentOff, 0.8f, product.Price >= 2000 && quantity >= 3));
        }

        /// <summary>
        /// Gets the product represented on the line.
        /// </summary>
        public Product Product { get; }

        /// <summary>
        /// Gets the quantity of items on the line
        /// </summary>
        public int Quantity { get; }

        /// <summary>
        /// Gets or sets the total value of the line.
        /// </summary>
        public float LineTotal { get; set; }

        /// <summary>
        /// The discounts available to be used.
        /// </summary>
        public List<Discount> AvailableDiscounts = new List<Discount>();

        /// <summary>
        /// Gets any discounts that the line qualifies for.
        /// </summary>
        public List<Discount> QualifyingDiscounts => AvailableDiscounts.Where(discount => discount.Condition).ToList();

        /// <summary>
        /// Calculates the total value of a line
        /// </summary>
        /// <returns>The total value for the line</returns>
        private float CalculateLineTotal()
        {
            if (!QualifyingDiscounts.Any())
            {
                return Product.Price * Quantity;
            }

            var bestDiscount = QualifyingDiscounts.Min(x => x.Modifier);

            return Product.Price * Quantity * bestDiscount;
        }
    }
}