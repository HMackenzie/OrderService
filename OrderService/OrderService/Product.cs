namespace OrderService
{
    public class Product
    {
        public Product(string productType, string productName, int price)
        {
            ProductType = productType;
            ProductName = productName;
            Price = price;
        }
        public string ProductType { get; }
        public string ProductName { get; }
        public int Price { get; }
    }
}