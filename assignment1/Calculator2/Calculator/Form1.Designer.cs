namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNum1 = new TextBox();
            txtNum2 = new TextBox();
            cmbOperator = new ComboBox();
            button1 = new Button();
            lblResult = new Label();
            SuspendLayout();
            // 
            // txtNum1
            // 
            txtNum1.Location = new Point(139, 121);
            txtNum1.Name = "txtNum1";
            txtNum1.Size = new Size(150, 30);
            txtNum1.TabIndex = 0;
            txtNum1.TextChanged += textBox1_TextChanged;
            // 
            // txtNum2
            // 
            txtNum2.Location = new Point(515, 123);
            txtNum2.Name = "txtNum2";
            txtNum2.Size = new Size(150, 30);
            txtNum2.TabIndex = 1;
            // 
            // cmbOperator
            // 
            cmbOperator.FormattingEnabled = true;
            cmbOperator.Items.AddRange(new object[] { "+", "-", "×", "÷" });
            cmbOperator.Location = new Point(308, 121);
            cmbOperator.Name = "cmbOperator";
            cmbOperator.Size = new Size(182, 32);
            cmbOperator.TabIndex = 2;
            cmbOperator.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(339, 198);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(308, 273);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 24);
            lblResult.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(button1);
            Controls.Add(cmbOperator);
            Controls.Add(txtNum2);
            Controls.Add(txtNum1);
            Name = "Form1";
            Text = "Calculator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNum1;
        private TextBox txtNum2;
        private ComboBox cmbOperator;
        private Button button1;
        private Label lblResult;
    }
}
