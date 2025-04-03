using System;

namespace Orders
{
    public class OrderDetails
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public OrderDetails() { }

        public OrderDetails(string productName, double unitPrice, int quantity)
        {
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public double TotalPrice
        {
            get { return UnitPrice * Quantity; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OrderDetails details))
                return false;
            return this.ProductName == details.ProductName;
        }

        public override int GetHashCode()
        {
            return ProductName.GetHashCode();
        }

        public override string ToString()
        {
            return $"商品: {ProductName}, 单价: {UnitPrice:C}, 数量: {Quantity}, 小计: {TotalPrice:C}";
        }
    }
}