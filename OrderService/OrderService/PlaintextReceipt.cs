using System;
using System.Text;

namespace OrderService
{
    /// <summary>
    /// Represents a plaintext receipt
    /// </summary>
    public class PlaintextReceipt : Receipt
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaintextReceipt"/> class.
        /// </summary>
        /// <param name="order"></param>
        public PlaintextReceipt(Order order)
        {
            Order = order;
            Body = GenerateBody();
        }

        /// <summary>
        /// Generates the reciept body.
        /// </summary>
        /// <returns>A string representation of the receipt body.</returns>
        public override string GenerateBody()
        {
            var result = new StringBuilder($"Order receipt for '{Order.Company}'{Environment.NewLine}");

            foreach (var line in Order.OrderLines)
            {
                result.AppendLine(
                    $"\t{line.Quantity} x {line.Product.ProductType} {line.Product.ProductName} = {line.LineTotal:C}");
            }

            result.AppendLine($"Subtotal: {Order.Subtotal:C}");
            result.AppendLine($"MVA: {Order.TaxPayable:C}");
            result.Append($"Total: {Order.TotalPayable:C}");
            return result.ToString();
        }
    }
}
