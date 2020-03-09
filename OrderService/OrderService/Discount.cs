namespace OrderService
{
    /// <summary>
    /// Represents a discount
    /// </summary>
    public class Discount
    { 
        /// <summary>
        /// Intitializes a new instance of the see
        /// </summary>
        /// <param name="type"></param>
        /// <param name="modifier"></param>
        public Discount(DiscountType type, float modifier, bool condition)
        {
            Type = type;
            Modifier = modifier;
            Condition = condition;
        }

        /// <summary>
        /// Gets or sets the type of discount being represented
        /// </summary>
        public DiscountType Type { get; set; }

        /// <summary>
        /// Gets or sets the condition(s) required for the discount to apply.
        /// </summary>
        public bool Condition { get; set; }

        /// <summary>
        /// Gets or sets a decimal multipler to modify the cost..
        /// </summary>
        public float Modifier { get; set; }
    }
}
