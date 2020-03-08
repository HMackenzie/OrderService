using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderService
{
    public class Order
    {
        private readonly IList<OrderLine> _orderLines = new List<OrderLine>();

        public Order(string company)
        {
            Company = company;
        }

        public string Company { get; set; }

        public const float TAXRATE = 0.25f;

        public void AddLine(OrderLine orderLine)
        {
            _orderLines.Add(orderLine);
        }

        //PARENT RECIEPT CLASS
        public string GenerateReceipt()
        {
            var totalAmount = 0d;
            var result = new StringBuilder($"Order receipt for '{Company}'{Environment.NewLine}");
            foreach (var line in _orderLines)
            {
                result.AppendLine(
                    $"\t{line.Quantity} x {line.Product.ProductType} {line.Product.ProductName} = {line.LineTotalPrice:C}");
                totalAmount += line.LineTotalPrice;
            }

            result.AppendLine($"Subtotal: {totalAmount:C}");
            var totalTax = totalAmount * TAXRATE;
            result.AppendLine($"MVA: {totalTax:C}");
            result.Append($"Total: {totalAmount + totalTax:C}");
            return result.ToString();
        }

        public string GenerateHtmlReceipt()
        {
            var totalAmount = 0d;
            var result = new StringBuilder($"<html><body><h1>Order receipt for '{Company}'</h1>");
            if (_orderLines.Any())
            {
                result.Append("<ul>");
                foreach (var line in _orderLines)
                {
                    result.Append(
                        $"<li>{line.Quantity} x {line.Product.ProductType} {line.Product.ProductName} = {line.LineTotalPrice:C}</li>");
                    totalAmount += line.LineTotalPrice;
                }

                result.Append("</ul>");
            }

            result.Append($"<h3>Subtotal: {totalAmount:C}</h3>");
            var totalTax = totalAmount * TAXRATE;
            result.Append($"<h3>MVA: {totalTax:C}</h3>");
            result.Append($"<h2>Total: {totalAmount + totalTax:C}</h2>");
            result.Append("</body></html>");
            return result.ToString();
        }
    }
}