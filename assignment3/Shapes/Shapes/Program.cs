using System;

// 抽象形状类
public abstract class Shape
{
    public abstract double CalculateArea();
    public abstract bool IsValid();
}

// 长方形类
public class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public override double CalculateArea()
    {
        return length * width;
    }

    public override bool IsValid()
    {
        return length > 0 && width > 0;
    }
}

// 正方形类
public class Square : Shape
{
    private double side;

    public Square(double side)
    {
        this.side = side;
    }

    public override double CalculateArea()
    {
        return side * side;
    }

    public override bool IsValid()
    {
        return side > 0;
    }
}

// 三角形类
public class Triangle : Shape
{
    private double a, b, c; // 三条边长

    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override double CalculateArea()
    {
        // 使用海伦公式计算三角形面积
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public override bool IsValid()
    {
        // 三角形任意两边之和大于第三边
        return a > 0 && b > 0 && c > 0 &&
               a + b > c && b + c > a && a + c > b;
    }
}

// 简单工厂类
public class ShapeFactory
{
    private static Random random = new Random();

    public static Shape CreateRandomShape()
    {
        int shapeType = random.Next(3); // 随机选择形状类型

        switch (shapeType)
        {
            case 0: // 创建长方形
                double length = random.Next(1, 10);
                double width = random.Next(1, 10);
                return new Rectangle(length, width);

            case 1: // 创建正方形
                double side = random.Next(1, 10);
                return new Square(side);

            case 2: // 创建三角形
                // 生成合法的三角形边长
                double a = random.Next(1, 10);
                double b = random.Next(1, 10);
                double c = random.Next((int)Math.Abs(a - b) + 1, (int)(a + b));
                return new Triangle(a, b, c);

            default:
                return null;
        }
    }
}

// 主程序
class Program
{
    static void Main(string[] args)
    {
        // 创建10个随机形状
        Shape[] shapes = new Shape[10];
        double totalArea = 0;

        for (int i = 0; i < 10; i++)
        {
            shapes[i] = ShapeFactory.CreateRandomShape();
            if (shapes[i].IsValid())
            {
                totalArea += shapes[i].CalculateArea();
                Console.WriteLine($"Shape {i + 1}: {shapes[i].GetType().Name}, Area: {shapes[i].CalculateArea():F2}");
            }
        }

        Console.WriteLine($"\nTotal area of all shapes: {totalArea:F2}");
    }
}
