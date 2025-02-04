using System.Drawing;

namespace Shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            Shape shape1 = new Circle(2.1);
            MyRectangle shape2 = new MyRectangle(23, 45);

            Console.WriteLine($"{shape2.width}");

            Shape shape3 = new Square(10);

            // no dependency on Circle
            double area = shape1.getArea();
            double area2 = shape2.getArea();
            double area3 = shape3.getArea();




            Console.WriteLine($"{area} and {area2} and {area3}");
        }
    }
}
