using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    // base class - general
    public abstract class Shape
    {
        public abstract double getArea();
    }

    // derived class (subclass)
    public class Circle : Shape
    {
        private double radius;

        // constructor (new Circle(1.0))
        public Circle(double my_radius)
        {
            this.radius = my_radius;
        }

        // method(function) override
        public override double getArea()
        {
            // Circle this;
            return Math.PI * this.radius * this.radius;
        }
    }

    public class MyRectangle : Shape
    {
        public double width;
        protected double height;

        public MyRectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double getArea()
        {
            return width * height;
        }
    }

    public class Square : MyRectangle
    {
        public Square(double side) : base(side, side)
        {
        }

        public override double getArea()
        {
            return this.width * this.width; 
        }

    }
}
