using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderDetails> Details { get; set; }

        public Order()
        {
            Details = new List<OrderDetails>();
            OrderTime = DateTime.Now;
        }

        public Order(int orderId, string customerName)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Details = new List<OrderDetails>();
            OrderTime = DateTime.Now;
        }

        public double TotalAmount
        {
            get { return Details.Sum(d => d.UnitPrice * d.Quantity); }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Order order))
                return false;
            return this.OrderId == order.OrderId;
        }

        public override int GetHashCode()
        {
            return OrderId.GetHashCode();
        }

        public override string ToString()
        {
            string result = $"订单号: {OrderId}, 客户: {CustomerName}, 订单时间: {OrderTime}, 总金额: {TotalAmount}\n";
            result += "订单明细:\n";
            foreach (var detail in Details)
            {
                result += "  " + detail.ToString() + "\n";
            }
            return result;
        }

        public void AddDetails(OrderDetails details)
        {
            if (Details.Contains(details))
                throw new ApplicationException($"订单明细已存在: {details.ProductName}");
            Details.Add(details);
        }

        public void RemoveDetails(OrderDetails details)
        {
            Details.Remove(details);
        }
    }
}