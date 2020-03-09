using System.Collections.Generic;
using System.Linq;

namespace OrderService
{
    /// <summary>
    /// Represents an order in the system.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The lines of the order.
        /// </summary>
        public readonly IList<OrderLine> OrderLines = new List<OrderLine>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="company"></param>
        public Order(string company)
        {
            Company = company;
        }

        /// <summary>
        /// Gets or sets the name of the company associated with the order.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// The taxrate to use for any tax calculations.
        /// </summary>
        public const float TAXRATE = 0.25f;

        /// <summary>
        /// Gets the total tax payable for the order.
        /// </summary>
        public float TaxPayable => Subtotal * TAXRATE;

        /// <summary>
        /// Gets the subtotal for the order.
        /// </summary>
        public float Subtotal => OrderLines.Sum(order => order.LineTotal);

        /// <summary>
        /// Gets the total balance payable for the order.
        /// </summary>
        public float TotalPayable => Subtotal + TaxPayable;
        
        /// <summary>
        /// Adds a new line to the order.
        /// </summary>
        /// <param name="orderLine"></param>
        public void AddLine(OrderLine orderLine)
        {
            OrderLines.Add(orderLine);
        }
    }
}