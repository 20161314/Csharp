﻿namespace GList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intList = new GenericList<int>();
            Random ran = new();
            for (int x = 0; x < 100; x++)
            {
                intList.Add(ran.Next(-100, 100));
            }

            // 打印元素
            intList.ForEach(data => Console.WriteLine(data));

            // 计算统计值
            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            intList.ForEach(data =>
            {
                max = Math.Max(max, data);
                min = Math.Min(min, data);
                sum += data;
            });

            Console.WriteLine($"Max: {max}, Min: {min}, Sum: {sum}");
        }

    }
}