namespace OrderService
{
    /// <summary>
    /// Abstract representation of a receipt.
    /// </summary>
    public abstract class Receipt
    {
        /// <summary>
        /// Gets or sets the order represented on the receipt.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the body of the receipt.
        /// </summary>
        public string Body { get; set; }

        public abstract string GenerateBody();
    }
}
