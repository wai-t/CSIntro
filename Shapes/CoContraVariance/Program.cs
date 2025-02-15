using System.Runtime.InteropServices;

namespace CoContraVariance
{

    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract void Scale(double scale);
    }
    public class Circle(double radius) : Shape
    {
        public double Radius { get; set; } = radius;

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override void Scale(double scale)
        {
            Radius *= scale;
        }

        public override string ToString()
        {
            return "Circle: " + Radius;
        }
    }

    public class Rectangle(double width, double height) : Shape
    {
        public double Width { get; set; } = width;
        public double Height { get; set; } = height;

        public override double GetArea()
        {
            return Width * Height;
        }

        public override void Scale(double scale)
        {
            Width *= scale;
            Height *= scale;
        }

        public override string ToString() => "Rectangle: " + Width + " x " + Height;
    }

    public class Square(double side) : Rectangle(side, side)
    {
        public override double GetArea()
        {
            return this.Width * this.Width;
        }

        public override string ToString() => "Square: " + Width;

    }

    // Contravariant type parameter. T is only used to declare input arguments for methods
    // Classes implementing this interface need to know how to resize something. The interface
    // places no constraint on what resize means, and it is up to the implementing class to
    // decide this. In the main program below, we will create a resizer that scales a Shape
    // by some amount.
    public interface IResizer<in T>
    {
        void Resize(T target); // T is input
    }

    // Covariant type parameter. U is only used to declare output (return) types
    // Classes implementing this interface need to know how to create objects of type U.
    // In the main program below, we will create factories for Rectangle, Square and Circle.
    public interface IShapeFactory<out U>
    {
        U MakeShape(); // U is output
    }

    // Our collection can contain only Rectangles and Squares
    public class MyRectangleCollection
    {
        readonly List<Rectangle> rectangles = [];

        // We want to be able to accept a IShapeFactory for Rectangles
        // and anything that "is a" Rectangle, i.e. derived from a Rectangle, like a Square
        public void Add(IShapeFactory<Rectangle> factory)
        {
            var rectangle = factory.MakeShape();
            rectangles.Add(rectangle);
        }

        // We want to be able to accept an IMagnifier that is for Rectangles or anything
        // that derives from a Rectangle, like Shape
        public void Magnify(IResizer<Rectangle> magnifier)
        {
            foreach (var r in rectangles)
            {
                magnifier.Resize(r);
            }
        }
        public override string ToString()
        {
            var ret = "";
            foreach (var r in rectangles)
            {
                ret += r.ToString() + "\n";
            }
            return ret;
        }
    }
    internal class Program
    {
        // Covariant interface, so we can also use this wherever a less derived type than Circle is expected
        class CircleMaker(double radius) : IShapeFactory<Circle>
        {
            public Circle MakeShape() => new Circle(radius);
        }

        // Covariant interface, so we can also use this wherever a less derived type than Square is expected
        class SquareMaker(double size) : IShapeFactory<Square>
        {
            public Square MakeShape() => new Square(size);
        }

        // Covariant interface, so we can also use this wherever a less derived type than Rectangle is expected
        class RectangleMaker(double width, double height) : IShapeFactory<Rectangle>
        {
            public Rectangle MakeShape() => new Rectangle(width, height);
        }

        // Contravariant interface, so we can also use this for anything that derives from Shape.
        // This implementation will magnify the Shape by {scale} times.
        class ShapeMagnifier(double scale) : IResizer<Shape>
        {
            public void Resize(Shape shape) => shape.Scale(scale);
        }

        class SquareMagnifier(double scale) : IResizer<Square>
        {
            public void Resize(Square shape) {
                shape.Width = shape.Height * scale;
                shape.Height = shape.Width;
            }
        }
        static void Main(string[] args)
        {
            var myRectangles = new MyRectangleCollection();

            // make our shape factories
            var squareMaker = new SquareMaker(2.0);
            var rectangleMaker = new RectangleMaker(1.5, 2.5);
            var circleMaker = new CircleMaker(3.0);

            myRectangles.Add(squareMaker); // Add() expected a IShapeFactory<Rectangle> so this is OK because Square derives from Rectangle.
            myRectangles.Add(rectangleMaker);
            // myRectangles.Add(circleMaker); // Conversion Error, can't convert Circle to Rectangle

            Console.WriteLine($"Shapes Added, \n{myRectangles}");

            var shapeMagnifer = new ShapeMagnifier(5.1);
            myRectangles.Magnify(shapeMagnifer);

            //var squareMagnifier = new SquareMagnifier(3.3);
            //myRectangles.Magnify(squareMagnifier); // Conversion Error.

            Console.WriteLine($"Shapes Magnified, \n{myRectangles}");

        }
    }
}
