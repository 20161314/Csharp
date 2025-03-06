using AlgorithmSolutions.MatrixValidation;
using AlgorithmSolutions.PrimeFactorization;
using AlgorithmSolutions.PrimeNumbers;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmSolutions.PrimeFactorization
{
    public static class PrimeFactorGenerator
    {
        public static List<int> GetPrimeFactors(int number)
        {
            if (number < 2) throw new ArgumentException("输入值必须大于1");

            var factors = new List<int>();
            int current = number;

            for (int factor = 2; factor * factor <= current; factor++)
            {
                factors.Add(factor);
                while (current % factor == 0)
                {
                    current /= factor;
                }
            }

            if (current > 1) factors.Add(current);
            return factors;
        }
    }
}

namespace AlgorithmSolutions.PrimeNumbers
{
    public static class SieveOfEratosthenes
    {
        public static List<int> GeneratePrimesUpTo100()
        {
            bool[] isPrime = new bool[101];
            Array.Fill(isPrime, true);
            isPrime[0] = isPrime[1] = false;

            for (int p = 2; p * p <= 100; p++)
            {
                if (!isPrime[p]) continue;

                for (int multiple = p * p; multiple <= 100; multiple += p)
                {
                    isPrime[multiple] = false;
                }
            }

            return Enumerable.Range(2, 99)
                .Where(num => isPrime[num])
                .ToList();
        }
    }
}

namespace AlgorithmSolutions.MatrixValidation
{
    public static class ToeplitzMatrixChecker
    {
        public static bool IsToeplitz(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return true;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                int[] currentRow = matrix[row];
                int[] nextRow = matrix[row + 1];

                for (int col = 0; col < currentRow.Length - 1; col++)
                {
                    if (currentRow[col] != nextRow[col + 1])
                        return false;
                }
            }
            return true;
        }
    }
}

namespace AlgorithmSolutions.ArrayStatistics
{
    public static class ArrayStatisticsCalculator
    {
        public static (int max, int min, double average, int sum) Calculate(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("数组不能为空");

            int max = numbers[0];
            int min = numbers[0];
            int sum = 0;

            foreach (int num in numbers)
            {
                max = Math.Max(max, num);
                min = Math.Min(min, num);
                sum += num;
            }

            double average = (double)sum / numbers.Length;
            return (max, min, average, sum);
        }
    }
}

namespace AlgorithmSolutions
{
    class Program
    {
        static void Main()
        {
            // 素数因子示例
            Console.WriteLine("28的素数因子: " +
                string.Join(", ", PrimeFactorGenerator.GetPrimeFactors(28)));

            // 数组统计示例
            int[] data = { 5, 2, 9, 1, 7 };
            var stats = AlgorithmSolutions.ArrayStatistics.ArrayStatisticsCalculator.Calculate(data);
            Console.WriteLine($"\n数组统计：\n最大值: {stats.max}" +
                $"\n最小值: {stats.min}\n平均值: {stats.average:N2}" +
                $"\n总和: {stats.sum}");

            // 素数生成示例
            Console.WriteLine("\n2-100的素数：\n" +
                string.Join(" ", SieveOfEratosthenes.GeneratePrimesUpTo100()));

            // 矩阵验证示例
            int[][] matrix = {
                new[] {1,2,3,4},
                new[] {5,1,2,3},
                new[] {9,5,1,2}
            };
            Console.WriteLine("\n托普利茨矩阵验证结果: " +
                ToeplitzMatrixChecker.IsToeplitz(matrix));
        }
    }
}