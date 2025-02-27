namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                double num1 = double.Parse(txtNum1.Text);
                double num2 = double.Parse(txtNum2.Text);
                string op = cmbOperator.SelectedItem.ToString();

                double result = Calculate(num1, num2, op);
                lblResult.Text = $"{num1} {op} {num2} = {result}";
                lblResult.ForeColor = System.Drawing.Color.Black;
            }
            catch (DivideByZeroException)
            {
                ShowError("除数不能为零！");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private bool ValidateInputs()
        {
            if (!double.TryParse(txtNum1.Text, out _))
            {
                ShowError("第一个数字输入无效");
                txtNum1.Focus();
                return false;
            }

            if (!double.TryParse(txtNum2.Text, out _))
            {
                ShowError("第二个数字输入无效");
                txtNum2.Focus();
                return false;
            }

            return true;
        }

        private double Calculate(double num1, double num2, string op)
        {
            switch (op)
            {
                case "+": return num1 + num2;
                case "-": return num1 - num2;
                case "×": return num1 * num2;
                case "÷":
                    if (num2 == 0) throw new DivideByZeroException();
                    return num1 / num2;
                default: throw new ArgumentException("无效运算符");
            }
        }

        private void ShowError(string message)
        {
            lblResult.Text = $"错误：{message}";
            lblResult.ForeColor = System.Drawing.Color.Red;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
