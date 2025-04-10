using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    public class OrderService
    {
        private List<Order> orders;

        public OrderService()
        {
            orders = new List<Order>();
        }

        // 添加订单
        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
                throw new ApplicationException($"订单已存在，订单号: {order.OrderId}");
            orders.Add(order);
        }

        // 删除订单
        public void RemoveOrder(int orderId)
        {
            Order orderToRemove = GetOrderById(orderId);
            if (orderToRemove == null)
                throw new ApplicationException($"订单不存在，订单号: {orderId}");
            orders.Remove(orderToRemove);
        }

        // 修改订单
        public void UpdateOrder(Order updatedOrder)
        {
            Order orderToUpdate = GetOrderById(updatedOrder.OrderId);
            if (orderToUpdate == null)
                throw new ApplicationException($"订单不存在，订单号: {updatedOrder.OrderId}");

            // 更新订单信息
            orderToUpdate.CustomerName = updatedOrder.CustomerName;

            // 清除原有明细并添加新明细
            orderToUpdate.Details.Clear();
            foreach (var detail in updatedOrder.Details)
            {
                orderToUpdate.AddDetails(detail);
            }
        }

        // 按订单号查询
        public Order GetOrderById(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        // 按客户名查询
        public List<Order> QueryByCustomerName(string customerName)
        {
            return orders.Where(o => o.CustomerName.Contains(customerName))
                         .OrderBy(o => o.TotalAmount)
                         .ToList();
        }

        // 按商品名查询
        public List<Order> QueryByProductName(string productName)
        {
            return orders.Where(o => o.Details.Any(d => d.ProductName.Contains(productName)))
                         .OrderBy(o => o.TotalAmount)
                         .ToList();
        }

        // 按金额范围查询
        public List<Order> QueryByAmountRange(double minAmount, double maxAmount)
        {
            return orders.Where(o => o.TotalAmount >= minAmount && o.TotalAmount <= maxAmount)
                         .OrderBy(o => o.TotalAmount)
                         .ToList();
        }

        // 获取所有订单
        public List<Order> GetAllOrders()
        {
            return orders.OrderBy(o => o.OrderId).ToList();
        }

        // 默认排序（按订单号）
        public void Sort()
        {
            orders = orders.OrderBy(o => o.OrderId).ToList();
        }

        // 自定义排序
        public void Sort(Func<Order, object> keySelector)
        {
            orders = orders.OrderBy(keySelector).ToList();
        }

        // 降序排序
        public void SortDescending(Func<Order, object> keySelector)
        {
            orders = orders.OrderByDescending(keySelector).ToList();
        }
    }
}