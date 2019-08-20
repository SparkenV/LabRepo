using System;

namespace Task2
{
    public class SecondTask
    {
        public static void Check()
        {
            IDrawable[] figures = CreateSomeObjects();
            DrawAll(figures);

            Console.ReadKey();
            Console.Clear();
        }

        private static void DrawAll(IDrawable[] figures)
        {
            foreach (var figure in figures)
            {
                figure.Draw();
            }
        }

        public static IDrawable[] CreateSomeObjects()
        {
            var figures = new IDrawable[3];

            double X;
            double Y;

            Console.WriteLine($"Введи X 1-ої фiгури: ");
            double.TryParse( Console.ReadLine(), out X);
            Console.WriteLine($"Введи Y 1-ої фiгури: ");
            double.TryParse(Console.ReadLine(), out Y);

            figures[0] = new Figure(X, Y);

            Console.WriteLine($"Введи X 2-ої фiгури: ");
            double.TryParse(Console.ReadLine(), out  X);
            Console.WriteLine($"Введи Y 2-ої фiгури: ");
            double.TryParse(Console.ReadLine(), out  Y);

            figures[1] = new Square(X, Y);

            Console.WriteLine($"Введи X 3-ої фiгури: ");
            double.TryParse(Console.ReadLine(), out X);
            Console.WriteLine($"Введи Y 3-ої фiгури: ");
            double.TryParse(Console.ReadLine(), out Y);

            figures[2] = new Rectangle(X, Y);

            return figures;
        }
    }


    public class Figure: IDrawable
    {
        public double X { get; }
        public double Y { get; }

        public Figure(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }


        public virtual void Draw()
        {
            Console.WriteLine($"Назва батькiвського класу: {this.GetType()} ({X};{Y})");  
        }
    }

    public class Square : Figure, IDrawable
    {
        public Square(double X, double Y) : base(X, Y)
        {
            
        }

        public override void Draw()
        {
            Console.WriteLine($"Назва першого похiдного класу: {this.GetType()} ({X};{Y})");
        }
    }

    public class Rectangle: Figure, IDrawable
    {
        public Rectangle(double X, double Y) : base(X, Y)
        {
        }

        public override void Draw()
        {
            Console.WriteLine($"Назва другого похiдного класу: {this.GetType()} ({X};{Y})");
        }
    }

    public interface IDrawable
    {
         void Draw();
    }
}
