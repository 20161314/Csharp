using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        private static OrderService orderService = new OrderService();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("欢迎使用订单管理系统");

            // 添加一些测试数据
            InitTestData();

            bool exit = false;
            while (!exit)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddOrder();
                            break;
                        case "2":
                            DeleteOrder();
                            break;
                        case "3":
                            ModifyOrder();
                            break;
                        case "4":
                            QueryOrderById();
                            break;
                        case "5":
                            QueryOrderByCustomerName();
                            break;
                        case "6":
                            QueryOrderByProductName();
                            break;
                        case "7":
                            QueryOrderByAmountRange();
                            break;
                        case "8":
                            ShowAllOrders();
                            break;
                        case "9":
                            SortOrders();
                            break;
                        case "0":
                            exit = true;
                            Console.WriteLine("感谢使用订单管理系统，再见！");
                            break;
                        case "t":
                            RunTests();
                            break;
                        default:
                            Console.WriteLine("无效的选择，请重新输入");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"操作失败: {ex.Message}");
                }

                if (!exit)
                {
                    Console.WriteLine("\n按任意键继续...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n===== 订单管理系统 =====");
            Console.WriteLine("1. 添加订单");
            Console.WriteLine("2. 删除订单");
            Console.WriteLine("3. 修改订单");
            Console.WriteLine("4. 按订单号查询");
            Console.WriteLine("5. 按客户名查询");
            Console.WriteLine("6. 按商品名查询");
            Console.WriteLine("7. 按金额范围查询");
            Console.WriteLine("8. 显示所有订单");
            Console.WriteLine("9. 订单排序");
            Console.WriteLine("0. 退出");
            Console.WriteLine("t. 运行测试");
            Console.Write("请选择操作: ");
        }

        static void InitTestData()
        {
            // 创建一些测试订单
            Order order1 = new Order(1, "张三");
            order1.AddDetails(new OrderDetails("笔记本电脑", 6999.99, 1));
            order1.AddDetails(new OrderDetails("鼠标", 99.99, 1));

            Order order2 = new Order(2, "李四");
            order2.AddDetails(new OrderDetails("手机", 4999.99, 1));
            order2.AddDetails(new OrderDetails("手机壳", 49.99, 1));
            order2.AddDetails(new OrderDetails("耳机", 299.99, 1));

            Order order3 = new Order(3, "王五");
            order3.AddDetails(new OrderDetails("键盘", 299.99, 1));
            order3.AddDetails(new OrderDetails("鼠标垫", 29.99, 1));

            try
            {
                orderService.AddOrder(order1);
                orderService.AddOrder(order2);
                orderService.AddOrder(order3);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"初始化测试数据失败: {ex.Message}");
            }
        }

        static void AddOrder()
        {
            Console.WriteLine("\n===== 添加订单 =====");

            Console.Write("请输入订单号: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("订单号必须是整数");
                return;
            }

            Console.Write("请输入客户名: ");
            string customerName = Console.ReadLine();

            Order newOrder = new Order(orderId, customerName);

            bool addingDetails = true;
            while (addingDetails)
            {
                Console.WriteLine("\n===== 添加订单明细 =====");
                Console.Write("请输入商品名称 (输入空白结束添加): ");
                string productName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(productName))
                {
                    addingDetails = false;
                    continue;
                }

                Console.Write("请输入单价: ");
                if (!double.TryParse(Console.ReadLine(), out double unitPrice) || unitPrice <= 0)
                {
                    Console.WriteLine("单价必须是正数");
                    continue;
                }

                Console.Write("请输入数量: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                {
                    Console.WriteLine("数量必须是正整数");
                    continue;
                }

                try
                {
                    newOrder.AddDetails(new OrderDetails(productName, unitPrice, quantity));
                    Console.WriteLine("订单明细添加成功");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"添加订单明细失败: {ex.Message}");
                }
            }

            if (newOrder.Details.Count == 0)
            {
                Console.WriteLine("订单必须包含至少一个订单明细");
                return;
            }

            orderService.AddOrder(newOrder);
            Console.WriteLine("订单添加成功");
        }

        static void DeleteOrder()
        {
            Console.WriteLine("\n===== 删除订单 =====");

            Console.Write("请输入要删除的订单号: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("订单号必须是整数");
                return;
            }

            orderService.RemoveOrder(orderId);
            Console.WriteLine("订单删除成功");
        }

        static void ModifyOrder()
        {
            Console.WriteLine("\n===== 修改订单 =====");

            Console.Write("请输入要修改的订单号: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("订单号必须是整数");
                return;
            }

            Order existingOrder = orderService.GetOrderById(orderId);
            if (existingOrder == null)
            {
                throw new ApplicationException($"订单不存在，订单号: {orderId}");
            }

            Console.Write($"请输入新的客户名 (当前: {existingOrder.CustomerName}): ");
            string customerName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(customerName))
            {
                existingOrder.CustomerName = customerName;
            }

            Console.WriteLine("是否修改订单明细? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                Order updatedOrder = new Order(orderId, existingOrder.CustomerName);

                bool addingDetails = true;
                while (addingDetails)
                {
                    Console.WriteLine("\n===== 添加订单明细 =====");
                    Console.Write("请输入商品名称 (输入空白结束添加): ");
                    string productName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(productName))
                    {
                        addingDetails = false;
                        continue;
                    }

                    Console.Write("请输入单价: ");
                    if (!double.TryParse(Console.ReadLine(), out double unitPrice) || unitPrice <= 0)
                    {
                        Console.WriteLine("单价必须是正数");
                        continue;
                    }

                    Console.Write("请输入数量: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                    {
                        Console.WriteLine("数量必须是正整数");
                        continue;
                    }

                    try
                    {
                        updatedOrder.AddDetails(new OrderDetails(productName, unitPrice, quantity));
                        Console.WriteLine("订单明细添加成功");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"添加订单明细失败: {ex.Message}");
                    }
                }

                if (updatedOrder.Details.Count == 0)
                {
                    Console.WriteLine("订单必须包含至少一个订单明细");
                    return;
                }

                orderService.UpdateOrder(updatedOrder);
            }

            Console.WriteLine("订单修改成功");
        }

        static void QueryOrderById()
        {
            Console.WriteLine("\n===== 按订单号查询 =====");

            Console.Write("请输入订单号: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("订单号必须是整数");
                return;
            }

            Order order = orderService.GetOrderById(orderId);
            if (order == null)
            {
                Console.WriteLine($"未找到订单号为 {orderId} 的订单");
                return;
            }

            Console.WriteLine("\n查询结果:");
            Console.WriteLine(order);
        }

        static void QueryOrderByCustomerName()
        {
            Console.WriteLine("\n===== 按客户名查询 =====");

            Console.Write("请输入客户名: ");
            string customerName = Console.ReadLine();

            List<Order> orders = orderService.QueryByCustomerName(customerName);
            DisplayQueryResults(orders);
        }

        static void QueryOrderByProductName()
        {
            Console.WriteLine("\n===== 按商品名查询 =====");

            Console.Write("请输入商品名: ");
            string productName = Console.ReadLine();

            List<Order> orders = orderService.QueryByProductName(productName);
            DisplayQueryResults(orders);
        }

        static void QueryOrderByAmountRange()
        {
            Console.WriteLine("\n===== 按金额范围查询 =====");

            Console.Write("请输入最小金额: ");
            if (!double.TryParse(Console.ReadLine(), out double minAmount) || minAmount < 0)
            {
                Console.WriteLine("金额必须是非负数");
                return;
            }

            Console.Write("请输入最大金额: ");
            if (!double.TryParse(Console.ReadLine(), out double maxAmount) || maxAmount < minAmount)
            {
                Console.WriteLine("最大金额必须大于或等于最小金额");
                return;
            }

            List<Order> orders = orderService.QueryByAmountRange(minAmount, maxAmount);
            DisplayQueryResults(orders);
        }

        static void DisplayQueryResults(List<Order> orders)
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("未找到符合条件的订单");
                return;
            }

            Console.WriteLine($"\n查询结果 (共 {orders.Count} 条记录):");
            foreach (var order in orders)
            {
                Console.WriteLine(order);
                Console.WriteLine("------------------------");
            }
        }

        static void ShowAllOrders()
        {
            Console.WriteLine("\n===== 所有订单 =====");

            List<Order> orders = orderService.GetAllOrders();
            DisplayQueryResults(orders);
        }

        static void SortOrders()
        {
            Console.WriteLine("\n===== 订单排序 =====");
            Console.WriteLine("1. 按订单号排序");
            Console.WriteLine("2. 按客户名排序");
            Console.WriteLine("3. 按订单时间排序");
            Console.WriteLine("4. 按订单金额排序");
            Console.Write("请选择排序方式: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    orderService.Sort(); // 默认按订单号排序
                    break;
                case "2":
                    orderService.Sort(o => o.CustomerName);
                    break;
                case "3":
                    orderService.Sort(o => o.OrderTime);
                    break;
                case "4":
                    orderService.Sort(o => o.TotalAmount);
                    break;
                default:
                    Console.WriteLine("无效的排序选择");
                    break;
            }

            Console.WriteLine("排序完成，请使用\"显示所有订单\"查看结果");
        }

        static void RunTests()
        {
            Console.WriteLine("\n===== 运行测试用例 =====");

            // 测试添加订单
            Console.WriteLine("\n测试1: 添加订单");
            Order testOrder = new Order(100, "测试客户");
            testOrder.AddDetails(new OrderDetails("测试商品", 100, 2));
            try
            {
                orderService.AddOrder(testOrder);
                Console.WriteLine("测试通过: 成功添加订单");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"测试失败: {ex.Message}");
            }

            // 测试添加重复订单
            Console.WriteLine("\n测试2: 添加重复订单");
            Order duplicateOrder = new Order(100, "重复客户");
            duplicateOrder.AddDetails(new OrderDetails("重复商品", 200, 1));
            try
            {
                orderService.AddOrder(duplicateOrder);
                Console.WriteLine("测试失败: 应该抛出异常但没有");
            }
            catch (ApplicationException)
            {
                Console.WriteLine("测试通过: 正确抛出异常，订单号重复");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"测试失败: 抛出了意外的异常 {ex.Message}");
            }

            // 测试查询订单
            Console.WriteLine("\n测试3: 按订单号查询");
            Order foundOrder = orderService.GetOrderById(100);
            if (foundOrder != null && foundOrder.OrderId == 100)
            {
                Console.WriteLine("测试通过: 成功查询到订单");
            }
            else
            {
                Console.WriteLine("测试失败: 未能查询到订单");
            }

            // 测试按客户名查询
            Console.WriteLine("\n测试4: 按客户名查询");
            List<Order> customerOrders = orderService.QueryByCustomerName("测试");
            if (customerOrders.Count > 0 && customerOrders.Any(o => o.CustomerName.Contains("测试")))
            {
                Console.WriteLine("测试通过: 成功按客户名查询订单");
            }
            else
            {
                Console.WriteLine("测试失败: 未能按客户名查询到订单");
            }

            // 测试按商品名查询
            Console.WriteLine("\n测试5: 按商品名查询");
            List<Order> productOrders = orderService.QueryByProductName("测试");
            if (productOrders.Count > 0)
            {
                Console.WriteLine("测试通过: 成功按商品名查询订单");
            }
            else
            {
                Console.WriteLine("测试失败: 未能按商品名查询到订单");
            }

            // 测试按金额范围查询
            Console.WriteLine("\n测试6: 按金额范围查询");
            List<Order> amountOrders = orderService.QueryByAmountRange(150, 250);
            if (amountOrders.Count > 0)
            {
                Console.WriteLine("测试通过: 成功按金额范围查询订单");
            }
            else
            {
                Console.WriteLine("测试失败: 未能按金额范围查询到订单");
            }

            // 测试修改订单
            Console.WriteLine("\n测试7: 修改订单");
            Order updatedOrder = new Order(100, "更新的客户");
            updatedOrder.AddDetails(new OrderDetails("更新的商品", 150, 1));
            try
            {
                orderService.UpdateOrder(updatedOrder);
                Order checkOrder = orderService.GetOrderById(100);
                if (checkOrder.CustomerName == "更新的客户" &&
                    checkOrder.Details.Any(d => d.ProductName == "更新的商品"))
                {
                    Console.WriteLine("测试通过: 成功修改订单");
                }
                else
                {
                    Console.WriteLine("测试失败: 订单修改不成功");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"测试失败: {ex.Message}");
            }

            // 测试删除订单
            Console.WriteLine("\n测试8: 删除订单");
            try
            {
                orderService.RemoveOrder(100);
                Order deletedOrder = orderService.GetOrderById(100);
                if (deletedOrder == null)
                {
                    Console.WriteLine("测试通过: 成功删除订单");
                }
                else
                {
                    Console.WriteLine("测试失败: 订单未被删除");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"测试失败: {ex.Message}");
            }

            // 测试删除不存在的订单
            Console.WriteLine("\n测试9: 删除不存在的订单");
            try
            {
                orderService.RemoveOrder(999);
                Console.WriteLine("测试失败: 应该抛出异常但没有");
            }
            catch (ApplicationException)
            {
                Console.WriteLine("测试通过: 正确抛出异常，订单不存在");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"测试失败: 抛出了意外的异常 {ex.Message}");
            }

            // 测试排序功能
            Console.WriteLine("\n测试10: 订单排序");
            try
            {
                orderService.Sort(o => o.TotalAmount);
                Console.WriteLine("测试通过: 成功按金额排序");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"测试失败: {ex.Message}");
            }
        }
    }
}