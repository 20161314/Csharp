using Orders;
using System;
using System.Windows.Forms;

namespace OrderManagerWinForm
{
    public partial class OrderForm : Form
    {
        public Order Order { get; private set; }

        public OrderForm(Order order = null)
        {
            InitializeComponent();
            InitializeBindings();

            if (order != null)
            {
                Order = new Order
                {
                    OrderId = order.OrderId,
                    CustomerName = order.CustomerName,
                    OrderTime = order.OrderTime
                };
                foreach (var detail in order.Details)
                {
                    Order.Details.Add(new OrderDetails
                    {
                        ProductName = detail.ProductName,
                        UnitPrice = detail.UnitPrice,
                        Quantity = detail.Quantity
                    });
                }
            }
            else
            {
                Order = new Order();
            }

            orderBindingSource.DataSource = Order;
            detailsBindingSource.DataSource = Order.Details;
        }

        private void InitializeBindings()
        {
            orderIdTextBox.DataBindings.Add("Text", orderBindingSource, "OrderId");
            customerNameTextBox.DataBindings.Add("Text", orderBindingSource, "CustomerName");

            detailsDataGridView.DataSource = detailsBindingSource;
        }

        private void addDetailButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productNameTextBox.Text) ||
                !double.TryParse(unitPriceTextBox.Text, out double unitPrice) ||
                !int.TryParse(quantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("请输入有效的商品信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var detail = new OrderDetails
                {
                    ProductName = productNameTextBox.Text,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                };

                Order.AddDetails(detail);
                detailsBindingSource.ResetBindings(false);

                productNameTextBox.Clear();
                unitPriceTextBox.Clear();
                quantityTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeDetailButton_Click(object sender, EventArgs e)
        {
            if (detailsDataGridView.CurrentRow != null)
            {
                var detail = detailsDataGridView.CurrentRow.DataBoundItem as OrderDetails;
                if (detail != null)
                {
                    Order.RemoveDetails(detail);
                    detailsBindingSource.ResetBindings(false);
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Order.CustomerName))
            {
                MessageBox.Show("请输入客户名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(orderIdTextBox.Text, out int orderId))
            {
                MessageBox.Show("请输入有效的订单号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Order.Details.Count == 0)
            {
                MessageBox.Show("请至少添加一个订单明细", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}