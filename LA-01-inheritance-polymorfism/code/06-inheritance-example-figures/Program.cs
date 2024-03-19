namespace _06_inheritance_example_figures
{
    public abstract class PlaneFigure
    {
        string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        bool hasHole;

        public PlaneFigure(string color)
        {
            this.color = color;
        }

        public void PunchHole()
        {
            hasHole = true;
        }

        override public string ToString()
        {
            return $"Color: {color} ; Lyukas: {hasHole} ; Area: {Area()} ; Circumference: {Circumference()}";
        }

        public abstract double Area();
        public abstract double Circumference();
    }

    public class Circle : PlaneFigure
    {
        double radius;

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Circle(string color, double radius) : base(color)
        {
            this.radius = radius;
        }

        override public string ToString()
        {
            return base.ToString() + " ; Radius: " + radius;
        }

        override public double Area()
        {
            return radius * radius * Math.PI;
        }

        override public double Circumference()
        {
            return 2 * radius * Math.PI;
        }
    }

    public class Rectangle : PlaneFigure
    {
        protected double width;

        virtual public double Width
        {
            get { return width; }
            set { width = value; }
        }

        protected double height;

        virtual public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public Rectangle(string color, double width, double height) : base(color)
        {
            this.width = width;
            this.height = height;
        }

        override public string ToString()
        {
            return base.ToString() + " ; Width: " + width + " ; Height: " + height;
        }

        override public double Area()
        {
            return width * height;
        }

        override public double Circumference()
        {
            return 2 * (width + height);
        }
    }

    public class Square : Rectangle
    {
        public Square(string color, double sideLength) : base(color, sideLength, sideLength)
        {
        }

        override public double Width
        {
            set
            {
                width = value;
                height = value;
            }
        }

        override public double Height
        {
            set
            {
                width = value;
                height = value;
            }
        }
    }
    internal class Program
    {
        public static void PunchHoleIfAreaIsBiggerThanCircumference(PlaneFigure figure)
        {
            if (figure.Area() > figure.Circumference())
            {
                figure.PunchHole();
            }
        }

        public static PlaneFigure CreateRectangleOrSquare(string color, double width, double height)
        {
            if (width == height)
            {
                return new Square(color, width);
            }
            else
            {
                return new Rectangle(color, width, height);
            }
        }

        public static PlaneFigure FindFigureWithBiggestArea(PlaneFigure[] figures)
        {
            int max = 0;
            for (int i = 1; i < figures.Length; i++)
            {
                if (figures[i].Area() > figures[max].Area())
                {
                    max = i;
                }
            }
            return figures[max];
        }

        static void Main(string[] args)
        {

            PlaneFigure[] figures = new PlaneFigure[5];

            Circle k1 = new Circle("red", 10);
            PlaneFigure sikidom = k1;
            figures[0] = sikidom;

            Rectangle t1 = new Rectangle("blue", 10, 20);
            figures[1] = t1;

            figures[2] = new Square("yellow", 10);
            figures[3] = new Circle("black", 5);
            figures[4] = new Square("black", 10);

            Console.WriteLine("\n\nList of items:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("\t" + figures[i]);
            }

            Console.WriteLine("\n\nCreate:");
            PlaneFigure output = CreateRectangleOrSquare("blue", 5, 5);
            PunchHoleIfAreaIsBiggerThanCircumference(output);
            Console.WriteLine(output);

            Console.WriteLine("\n\nBiggest area:");
            PlaneFigure biggest = FindFigureWithBiggestArea(figures);
            Console.WriteLine(biggest);
        }
    }
}