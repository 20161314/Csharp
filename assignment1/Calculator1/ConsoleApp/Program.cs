using System;

namespace myApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                double num1 = GetNumber("请输入第一个数字: ");
                char op = GetOperator();
                double num2 = GetNumber("请输入第二个数字: ");

                double result = Calculate(num1, num2, op);
                Console.WriteLine($"计算结果: {num1} {op} {num2} = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
            }
        }

        static double GetNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                {
                    return number;
                }
                Console.WriteLine("输入无效，请输入有效的数字！");
            }
        }

        static char GetOperator()
        {
            while (true)
            {
                Console.Write("请输入运算符 (+ - * /): ");
                string input = Console.ReadLine();
                if (input.Length == 1 && "+-*/".Contains(input))
                {
                    return input[0];
                }
                Console.WriteLine("无效运算符，请使用 +, -, *, 或 /");
            }
        }

        static double Calculate(double num1, double num2, char op)
        {
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 == 0)
                    {
                        throw new DivideByZeroException("除数不能为零！");
                    }
                    return num1 / num2;
                default:
                    throw new ArgumentException("不支持的运算符");
            }
        }
    }
}
