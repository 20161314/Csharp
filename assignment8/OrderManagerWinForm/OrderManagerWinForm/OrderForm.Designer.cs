namespace OrderManagerWinForm
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.orderPanel = new System.Windows.Forms.Panel();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.orderIdLabel = new System.Windows.Forms.Label();
            this.orderIdTextBox = new System.Windows.Forms.TextBox();
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.detailsDataGridView = new System.Windows.Forms.DataGridView();
            this.detailInputPanel = new System.Windows.Forms.Panel();
            this.addDetailButton = new System.Windows.Forms.Button();
            this.removeDetailButton = new System.Windows.Forms.Button();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.unitPriceLabel = new System.Windows.Forms.Label();
            this.unitPriceTextBox = new System.Windows.Forms.TextBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailsBindingSource)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.orderPanel.SuspendLayout();
            this.detailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailsDataGridView)).BeginInit();
            this.detailInputPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.orderPanel, 0, 0);
            this.mainPanel.Controls.Add(this.detailsPanel, 0, 1);
            this.mainPanel.Controls.Add(this.detailInputPanel, 0, 2);
            this.mainPanel.Controls.Add(this.buttonPanel, 0, 3);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 4;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainPanel.Size = new System.Drawing.Size(584, 461);
            this.mainPanel.TabIndex = 0;
            // 
            // orderPanel
            // 
            this.orderPanel.Controls.Add(this.customerNameLabel);
            this.orderPanel.Controls.Add(this.customerNameTextBox);
            this.orderPanel.Controls.Add(this.orderIdLabel);
            this.orderPanel.Controls.Add(this.orderIdTextBox);
            this.orderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderPanel.Location = new System.Drawing.Point(3, 3);
            this.orderPanel.Name = "orderPanel";
            this.orderPanel.Size = new System.Drawing.Size(578, 54);
            this.orderPanel.TabIndex = 0;
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Location = new System.Drawing.Point(200, 22);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(53, 12);
            this.customerNameLabel.TabIndex = 2;
            this.customerNameLabel.Text = "客户名：";
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Location = new System.Drawing.Point(259, 19);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.Size = new System.Drawing.Size(150, 21);
            this.customerNameTextBox.TabIndex = 3;
            // 
            // orderIdLabel
            // 
            this.orderIdLabel.AutoSize = true;
            this.orderIdLabel.Location = new System.Drawing.Point(20, 22);
            this.orderIdLabel.Name = "orderIdLabel";
            this.orderIdLabel.Size = new System.Drawing.Size(53, 12);
            this.orderIdLabel.TabIndex = 0;
            this.orderIdLabel.Text = "订单号：";
            // 
            // orderIdTextBox
            // 
            this.orderIdTextBox.Location = new System.Drawing.Point(79, 19);
            this.orderIdTextBox.Name = "orderIdTextBox";
            this.orderIdTextBox.Size = new System.Drawing.Size(100, 21);
            this.orderIdTextBox.TabIndex = 1;
            // 
            // detailsPanel
            // 
            this.detailsPanel.Controls.Add(this.detailsDataGridView);
            this.detailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsPanel.Location = new System.Drawing.Point(3, 63);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.Size = new System.Drawing.Size(578, 245);
            this.detailsPanel.TabIndex = 1;
            // 
            // detailsDataGridView
            // 
            this.detailsDataGridView.AllowUserToAddRows = false;
            this.detailsDataGridView.AllowUserToDeleteRows = false;
            this.detailsDataGridView.AutoGenerateColumns = false;
            this.detailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.detailsDataGridView.Name = "detailsDataGridView";
            this.detailsDataGridView.ReadOnly = true;
            this.detailsDataGridView.RowTemplate.Height = 23;
            this.detailsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.detailsDataGridView.Size = new System.Drawing.Size(578, 245);
            this.detailsDataGridView.TabIndex = 0;
            // 
            // detailInputPanel
            // 
            this.detailInputPanel.Controls.Add(this.addDetailButton);
            this.detailInputPanel.Controls.Add(this.removeDetailButton);
            this.detailInputPanel.Controls.Add(this.productNameLabel);
            this.detailInputPanel.Controls.Add(this.productNameTextBox);
            this.detailInputPanel.Controls.Add(this.unitPriceLabel);
            this.detailInputPanel.Controls.Add(this.unitPriceTextBox);
            this.detailInputPanel.Controls.Add(this.quantityLabel);
            this.detailInputPanel.Controls.Add(this.quantityTextBox);
            this.detailInputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailInputPanel.Location = new System.Drawing.Point(3, 314);
            this.detailInputPanel.Name = "detailInputPanel";
            this.detailInputPanel.Size = new System.Drawing.Size(578, 94);
            this.detailInputPanel.TabIndex = 2;
            // 
            // addDetailButton
            // 
            this.addDetailButton.Location = new System.Drawing.Point(400, 60);
            this.addDetailButton.Name = "addDetailButton";
            this.addDetailButton.Size = new System.Drawing.Size(75, 23);
            this.addDetailButton.TabIndex = 7;
            this.addDetailButton.Text = "添加明细";
            this.addDetailButton.UseVisualStyleBackColor = true;
            this.addDetailButton.Click += new System.EventHandler(this.addDetailButton_Click);
            // 
            // removeDetailButton
            // 
            this.removeDetailButton.Location = new System.Drawing.Point(481, 60);
            this.removeDetailButton.Name = "removeDetailButton";
            this.removeDetailButton.Size = new System.Drawing.Size(75, 23);
            this.removeDetailButton.TabIndex = 8;
            this.removeDetailButton.Text = "删除明细";
            this.removeDetailButton.UseVisualStyleBackColor = true;
            this.removeDetailButton.Click += new System.EventHandler(this.removeDetailButton_Click);
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Location = new System.Drawing.Point(20, 15);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(53, 12);
            this.productNameLabel.TabIndex = 0;
            this.productNameLabel.Text = "商品名：";
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Location = new System.Drawing.Point(79, 12);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(150, 21);
            this.productNameTextBox.TabIndex = 1;
            // 
            // unitPriceLabel
            // 
            this.unitPriceLabel.AutoSize = true;
            this.unitPriceLabel.Location = new System.Drawing.Point(235, 15);
            this.unitPriceLabel.Name = "unitPriceLabel";
            this.unitPriceLabel.Size = new System.Drawing.Size(41, 12);
            this.unitPriceLabel.TabIndex = 2;
            this.unitPriceLabel.Text = "单价：";
            // 
            // unitPriceTextBox
            // 
            this.unitPriceTextBox.Location = new System.Drawing.Point(282, 12);
            this.unitPriceTextBox.Name = "unitPriceTextBox";
            this.unitPriceTextBox.Size = new System.Drawing.Size(100, 21);
            this.unitPriceTextBox.TabIndex = 3;
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(388, 15);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(41, 12);
            this.quantityLabel.TabIndex = 4;
            this.quantityLabel.Text = "数量：";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(435, 12);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(100, 21);
            this.quantityTextBox.TabIndex = 5;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.okButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(3, 414);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(578, 44);
            this.buttonPanel.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(400, 10);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(481, 10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "订单编辑";
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailsBindingSource)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.orderPanel.ResumeLayout(false);
            this.orderPanel.PerformLayout();
            this.detailsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailsDataGridView)).EndInit();
            this.detailInputPanel.ResumeLayout(false);
            this.detailInputPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.BindingSource detailsBindingSource;
        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Panel orderPanel;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.TextBox customerNameTextBox;
        private System.Windows.Forms.Label orderIdLabel;
        private System.Windows.Forms.TextBox orderIdTextBox;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.DataGridView detailsDataGridView;
        private System.Windows.Forms.Panel detailInputPanel;
        private System.Windows.Forms.Button addDetailButton;
        private System.Windows.Forms.Button removeDetailButton;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.Label unitPriceLabel;
        private System.Windows.Forms.TextBox unitPriceTextBox;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}