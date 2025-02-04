using System.Drawing;

namespace Shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(2.1);
            MyRectangle rectangle = new MyRectangle(23, 45);
            Square square = new Square(10);

            GetShapeData(circle, rectangle, square);
            GetDimensionData(circle, rectangle, new Blob());

        }

        // Generic function that only knows about IDimension
        private static void GetDimensionData(IDimension dim1, IDimension dim2, IDimension dim3)
        {
            Console.WriteLine($"Is2d {dim1.Is2D()} {dim2.Is2D()} {dim3.Is2D()}");
        }

        // Generic function that only knows about IAreaProvider
        private static void GetShapeData(IAreaProvider shape1, IAreaProvider shape2, IAreaProvider shape3)
        {
            double area = shape1.GetArea();
            double area2 = shape2.GetArea();
            double area3 = shape3.GetArea();

            Console.WriteLine($"{area} and {area2} and {area3}");
        }
    }
}
