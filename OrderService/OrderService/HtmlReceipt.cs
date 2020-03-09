using System.Text;

namespace OrderService
{
    /// <summary>
    /// Represents an hmtl receipt
    /// </summary>
    public class HtmlReceipt : Receipt
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlReceipt"/> class.
        /// </summary>
        /// <param name="order"></param>
        public HtmlReceipt(Order order)
        {
            Order = order;
            Body = GenerateBody();
        }

        /// <summary>
        /// Generates the receipt body.
        /// </summary>
        /// <returns>A string representation of the receipt body.</returns>
        public override string GenerateBody()
        {
            var result = new StringBuilder($"<html><body><h1>Order receipt for '{Order.Company}'</h1>");
            if (Order.OrderLines.Count > 0)
            {
                result.Append("<ul>");
                foreach (var line in Order.OrderLines)
                {
                    result.Append(
                        $"<li>{line.Quantity} x {line.Product.ProductType} {line.Product.ProductName} = {line.LineTotal:C}</li>");
                }

                result.Append("</ul>");
            }

            result.Append($"<h3>Subtotal: {Order.Subtotal:C}</h3>");
            result.Append($"<h3>MVA: {Order.TaxPayable:C}</h3>");
            result.Append($"<h2>Total: {Order.TotalPayable:C}</h2>");
            result.Append("</body></html>");
            return result.ToString();
        }

    }
}
