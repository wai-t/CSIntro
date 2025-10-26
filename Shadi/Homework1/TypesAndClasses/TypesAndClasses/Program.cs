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

            Console.WriteLine("Please Enter your side ");
            double side = double.Parse(Console.ReadLine());

            Console.WriteLine("Please Enter three different sides for triangle");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            Console.WriteLine("Please Enter Heigth and Length for the rectangle");
            double length = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());


            Shape circle = new Circle(side);
            Shape square = new Square(side);
            Shape equilateraltriangle = new equilateraltriangle(side);
            Shape triangle = new triangle(a, b, c);
            Shape regtangle = new Rectangle(heigth, length);


            WriteShapePremiter(circle, "circle");
            WriteShapePremiter(square, "square");
            WriteShapePremiter(equilateraltriangle, "equilateral triangle");
            WriteShapePremiter(triangle, "triangle");
            WriteShapePremiter(regtangle, "Regtangle");


        }

        static void WriteShapePremiter(Shape shape, string name)
        {
            Console.WriteLine($"{name} perimeter  is {shape.Perimeter()} ||  Area is  {shape.Area()}  ||  RatioOfAreaAndPerimeter is {shape.RatioOfAreaAndPerimeter()}");


        }



        public abstract class Shape
        {
            public abstract double Perimeter();
            public abstract double Area();
            public double RatioOfAreaAndPerimeter()
            {

                if (Perimeter() == 0 && Area() == 0) return 0;

                return Area() / Perimeter();
            }
        }

        public class equilateraltriangle : Shape
        {
            double side;
            public equilateraltriangle(double side)
            {
                this.side = side;
            }

            public override double Perimeter()
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

            double length, heigth;


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





        // Homework
        // Add an new method ( double Area()) to Shape and implement for the three shapes



        // Write another method that calculates Area/Perimeter for each Shape. Call it RatioOfAreaAndPerimeter



        // Change the constructors of the shapes so that you can provide the side.



        // Make the Triangle an irregular triangle  (3 sides are different).



        // Make the Square a rectangle instead

    }
}