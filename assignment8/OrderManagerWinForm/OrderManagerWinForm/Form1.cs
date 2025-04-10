using Orders;
using System;
using System.Windows.Forms;
using System.Linq;

namespace OrderManagerWinForm
{
    public partial class Form1 : Form
    {
        private OrderService orderService;

        public Form1()
        {
            InitializeComponent();
            InitializeOrderService();
            InitializeDataGridView();
            BindEvents();
        }

        private void InitializeOrderService()
        {
            orderService = new OrderService();
            orderBindingSource.DataSource = orderService.GetAllOrders();
        }

        private void InitializeDataGridView()
        {
            // 设置订单DataGridView的列
            orderDataGridView.DataSource = orderBindingSource;
            orderDataGridView.Columns.Clear();
            orderDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OrderId", HeaderText = "订单号", Width = 80 });
            orderDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerName", HeaderText = "客户名", Width = 120 });
            orderDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OrderTime", HeaderText = "订单时间", Width = 150 });
            orderDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "总金额", Width = 100 });

            // 设置订单明细DataGridView的列
            detailsBindingSource.DataSource = orderBindingSource;
            detailsBindingSource.DataMember = "Details";
            detailsDataGridView.DataSource = detailsBindingSource;
            detailsDataGridView.Columns.Clear();
            detailsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "商品名", Width = 150 });
            detailsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "单价", Width = 100 });
            detailsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "数量", Width = 80 });
            detailsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalPrice", HeaderText = "小计", Width = 100 });
        }

        private void BindEvents()
        {
            searchButton.Click += SearchButton_Click;
            addButton.Click += AddButton_Click;
            editButton.Click += EditButton_Click;
            deleteButton.Click += DeleteButton_Click;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text)) return;

            switch (searchTypeComboBox.SelectedIndex)
            {
                case 0: // 按订单号
                    if (int.TryParse(searchTextBox.Text, out int orderId))
                    {
                        var order = orderService.GetOrderById(orderId);
                        orderBindingSource.DataSource = order != null ? new[] { order } : new Order[0];
                    }
                    break;
                case 1: // 按客户名
                    orderBindingSource.DataSource = orderService.QueryByCustomerName(searchTextBox.Text);
                    break;
                case 2: // 按商品名
                    orderBindingSource.DataSource = orderService.QueryByProductName(searchTextBox.Text);
                    break;
                default:
                    orderBindingSource.DataSource = orderService.GetAllOrders();
                    break;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var form = new OrderForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        orderService.AddOrder(form.Order);
                        orderBindingSource.DataSource = orderService.GetAllOrders();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var order = orderBindingSource.Current as Order;
            if (order == null) return;

            using (var form = new OrderForm(order))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        orderService.UpdateOrder(form.Order);
                        orderBindingSource.DataSource = orderService.GetAllOrders();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var order = orderBindingSource.Current as Order;
            if (order == null) return;

            if (MessageBox.Show($"确定要删除订单 {order.OrderId} 吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    orderService.RemoveOrder(order.OrderId);
                    orderBindingSource.DataSource = orderService.GetAllOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
