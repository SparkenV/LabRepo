using System;

namespace Task1
{
    public static class FirstTask{
        public static void Check()
        {
            WorkWithRectangle();
            WorkWithCircle();
            WirkWithComplexNumbers();
        }

        public static void WorkWithRectangle()
        {
            Console.WriteLine("Робота з прямокутником");

            Console.Write("Введи X1: ");
            float.TryParse(Console.ReadLine(), out float x1);
            Console.Write("Введи Y1: ");
            float.TryParse(Console.ReadLine(), out float y1);

            Console.Write("Введи X2: ");
            float.TryParse(Console.ReadLine(), out float x2);
            Console.Write("Введи Y2: ");
            float.TryParse(Console.ReadLine(), out float y2);

            float perimeter = Rectangle.GetPerimeter(new Vector2(x1, y1), new Vector2(x2, y2));
            Console.WriteLine($"Переметр = {perimeter}");
            float area = Rectangle.GetArea(new Vector2(x1, y1), new Vector2(x2, y2));
            Console.WriteLine($"Площа = {area}");

            Console.ReadKey();
            Console.Clear();
        }

        public static void WorkWithCircle()
        {
            Console.WriteLine("Робота з колом");

            Console.Write("Введи радiус: ");
            float.TryParse(Console.ReadLine(), out float radius);

            float perimetr = Circle.GetArea(radius);
            Console.WriteLine($"Периметр = {perimetr}");

            float area = Circle.GetPerimeter(radius);
            Console.WriteLine($"Площа = {area}");

            Console.ReadKey();
            Console.Clear();
        }

        public static void WirkWithComplexNumbers()
        {
            Console.WriteLine("Робота з комплексними числами");

            Console.Write("Введи реальну частину першого числа: ");
            int.TryParse(Console.ReadLine(), out int complex1r);
            Console.Write("Введи уявну частину першого числа: ");
            int.TryParse(Console.ReadLine(), out int complex1i);

            Console.Write("Введи реальну частину другого числа: ");
            int.TryParse(Console.ReadLine(), out int complex2r);
            Console.Write("Введи уявну частину другого числа: ");
            int.TryParse(Console.ReadLine(), out int complex2i);

            ComplexNumber complex1 = new ComplexNumber(complex1r, complex1i);
            ComplexNumber complex2 = new ComplexNumber(complex2r, complex2i);

            ComplexNumber resultOfMultiplying = complex1 * complex2;
            ComplexNumber resultOfDividing = complex1 / complex2;

            Console.WriteLine($"Результат множення: {complex1} на {complex2} = {resultOfMultiplying}");
            Console.WriteLine($"Результат дiлення: {complex1} на {complex2} = {resultOfDividing}");

            Console.ReadKey();
            Console.Clear();
        }
    }

    public static class Rectangle
    {
        public static float GetPerimeter(Vector2 point1, Vector2 point2)
        {
            var sideA = Abs(point1.x - point2.x);
            var sideB = Abs(point1.y - point2.y);
            return sideA * 2 + sideB * 2;
        }

        public static float GetArea(Vector2 point1, Vector2 point2)
        {
            var sideA = Abs(point1.x - point2.x);
            var sideB = Abs(point1.y - point2.y);
            return sideA * sideB;
        }

        private static float Abs(float number)
        {
            return (number < 0) ? (number * -1) : number;
        }
    }
    public static class Circle
    {
        public static float GetPerimeter(float radius)
        {
            return 2 * 3.14f * radius;
        }

        public static float GetArea(float radius)
        {
            return 3.14f * radius * radius;
        }
    }
    public class Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class ComplexNumber
    {
        #region Fields
        public int realNumber;
        public int imaginary;
        #endregion

        #region Constructor
        public ComplexNumber(int real, int imaginary)
        {
            this.realNumber = real;
            this.imaginary = imaginary;
        }
        #endregion

        #region Static methods
        public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber(first.realNumber * second.realNumber - first.imaginary * second.imaginary,
                first.realNumber * second.imaginary + first.imaginary * second.realNumber);
        }
        public static ComplexNumber operator /(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber((first.realNumber * second.realNumber + first.imaginary * second.imaginary) / second.realNumber * second.realNumber + second.imaginary * second.imaginary,
                (first.imaginary * second.realNumber - first.realNumber * second.imaginary) / second.realNumber * second.realNumber + second.imaginary * second.imaginary);
        }
        #endregion

        public override string ToString()
        {
            return $"{realNumber} + {imaginary}i";
        }
    }
}