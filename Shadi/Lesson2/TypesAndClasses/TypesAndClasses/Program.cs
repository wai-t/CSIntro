using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace TypesAndClasses
{
    internal class Program
    {
        string programName = "Program";

        static void Main(string[] args)
        {

            //Console.WriteLine("Please Enter your side ");
            //double side = double.Parse(Console.ReadLine());

            //Console.WriteLine("Please Enter three different sides for triangle");
            //double a = double.Parse(Console.ReadLine());
            //double b = double.Parse(Console.ReadLine());
            //double c = double.Parse(Console.ReadLine());

            //Console.WriteLine("Please Enter Heigth and Length for the rectangle");
            //double length = double.Parse(Console.ReadLine());
            //double heigth = double.Parse(Console.ReadLine());


            //Shape circle1 = new Circle(side);
            //Shape square = new Square(side);
            //Shape equilateraltriangle = new equilateraltriangle(side);
            //Shape triangle = new triangle(a, b, c);
            //Shape regtangle = new Rectangle(heigth, length);


            //WriteShapePremiter(circle1, "circle1");
            //WriteShapePremiter(square, "square");
            //WriteShapePremiter(equilateraltriangle, "equilateral triangle");
            //WriteShapePremiter(triangle, "triangle");
            //WriteShapePremiter(regtangle, "Regtangle");

            var square = new MySquare(3.0);
            var squarePerimeter = square.Perimeter();

            equilateraltriangle etriangle = new equilateraltriangle(1.0); 
            Shape triangle = etriangle;

            var name1 = etriangle.GetShapeName();
            var name2 = triangle.GetShapeName();

            // polymorphism
            var vname1 = etriangle.GetOverrideShapeName();
            var vname2 = triangle.GetOverrideShapeName();


            Shape circle1 = new Circle(1.0);
            Shape circle2 = new Circle(2.0);

            // non-static fields and methods can only be accessed using the variable (the object)
            circle2.myNonStaticName = "Circle2";
            var longName = circle2.GetLongName();

            // static field and methods can only be accessed using the class name (the blueprint),
            // and you don't need to create any objects.
            Circle.myName = "StaticC2";
            var name = Circle.GetName();
        }

        static void WriteShapePremiter(Shape shape, string name)
        {
            Console.WriteLine($"{name} perimeter  is {shape.Perimeter()} ||  Area is  {shape.Area()}  ||  RatioOfAreaAndPerimeter is {shape.RatioOfAreaAndPerimeter()}");


        }


        //
        // With abstract class, you cannot do: new Shape();
        // This is good because new Shape() means nothing.
        //
        public abstract class Shape
        {
            static public string myName = "Shape";
            public string myNonStaticName = "Nonstatic";
            public abstract double Perimeter(); // abstract method means there is a method but there is no code
            public abstract double Area();

            public static string GetName()
            {
                return myName; // static methods can only access static fields
            }

            public string GetLongName()
            {
                return myName + myNonStaticName; // non-static methods can access static fields
            }

            public string GetShapeName()
            {
                return "Shape";
            }

            public virtual string GetOverrideShapeName()
            {
                return "Shape";
            }

            public double RatioOfAreaAndPerimeter() // concrete method is allowed, even though you can't create just a Shape
            {

                if (Perimeter() == 0 && Area() == 0) return 0;

                return Area() / Perimeter();
            }
        }

        // interface usually means methods, i.e. the name, return type, and the parameters.
        // implementation usually means the code inside the method.
        // abstract method has only and interface and no implementation.
        // method has both.

        // abstract, virtual and override
        // at the base level use abstract (if there is no code), and virtual if there is code
        // at every level below use override

        // if not inheriting (but hiding), use "new" to tell compiler you know what you are doing.

        // static and non-static.

        public class equilateraltriangle : Shape
        {
            double side;
            public equilateraltriangle(double side)
            {
                this.side = side;
            }

            public new string GetShapeName() // the new keyword tells C# I want to hide the base class function without overriding.
            {
                return "ETriangle";
            }
            public override string GetOverrideShapeName()
            {
                return "ETriangle";
            }
            public override double Perimeter() // override means that we are overriding the base method.
            {
                return side * 3;

            }

            public override double Area()
            {
                return Math.Sqrt(side) / 4 * side * side;
            }

        }


        public class triangle : Shape
        {

            double s, a, b, c;

            public triangle(double a, double b, double c)
            {

                this.a = a;
                this.b = b;
                this.c = c;


            }

            public override double Perimeter()
            {

                return a + b + c;
            }
            public override double Area()
            {
                if (a + b <= c || a + c <= b || b + c <= a)
                    throw new ArgumentException("invalid trangle sizes");
                double s = Perimeter() / 2;
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            }
        }

        public class Circle : Shape
        {
            double side;

            public Circle(double side)
            {
                this.side = side;
            }

            public override double Perimeter()
            {
                return 2.0 * Math.PI * side;
            }

            public override double Area()
            {
                return Math.PI * side * side;
            }
        }

        public class Square : Shape
        {
            double side;

            public Square(double side)
            {
                this.side = side;
            }
            public override double Perimeter()
            {
                return 4 * side;
            }

            public override double Area()
            {
                return side * side;
            }
        }


        public class Rectangle : Shape
        {

            protected double length, heigth;

            public Rectangle()
            {
                this.length = 1;
                this.heigth = 1;
            }

            public Rectangle(string x)
            {
                this.length = 2;
                this.heigth = 3;
            }

            public Rectangle(double length, double height)
            {

                this.length = length;
                this.heigth = height;
            }

            public override double Perimeter()
            {
                return (length + heigth) * 2;
            }

            public override double Area()
            {
                return length * heigth;
            }

        }

        public class MySquare : Rectangle
        {
            public MySquare() : base("strin")
            {

            }
            public MySquare(string s) : base(1.0, 2.0)
            {

            }
            public MySquare(double side) : base(side, side)
            {
            }
            public override double Perimeter()
            {
                Console.WriteLine("You called MySquare.Perimeter");
                return base.Perimeter();
            }

            //public override double Area()
            //{
            //    return heigth * length;
            //}
        }





        // Homework
        // Add an new method ( double Area()) to Shape and implement for the three shapes



        // Write another method that calculates Area/Perimeter for each Shape. Call it RatioOfAreaAndPerimeter



        // Change the constructors of the shapes so that you can provide the side.



        // Make the Triangle an irregular triangle  (3 sides are different).



        // Make the Square a rectangle instead

    }
}