//#define USE_CLASS

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
#if USE_CLASS
    // base class - general
    // declared abstract because it's never valid to say "new Shape(...)"
    public abstract class Shape 
    {
        public abstract double getArea(); // signature of the function
        public string getMyClassName() => "Shape";
    }
#else
    public interface IAreaProvider
    {
        public double GetArea(); // signature of the function
        public string GetMyClassName() => "Shape";

        public static string GetStaticStuff() => "StaticStuf";

    }
    public interface IDimension
    {
        public bool Is2D();
        public bool Is3D();
    }
#endif
    // derived class (subclass)
    public class Circle : IAreaProvider, IDimension
    {
        private double radius;

        // constructor (new Circle(1.0))
        public Circle(double my_radius)
        {
            this.radius = my_radius;
        }

        public virtual double GetArea() // might as well use virtual in case we need to derive from it later
        {
            return Math.PI * this.radius * this.radius;
        }

        public bool Is2D() => true;

        public bool Is3D()=>false;

    }

    public class MyRectangle : IAreaProvider, IDimension
    {
        public double width;
        protected double height;

        public MyRectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        // virtual is needed because Square is going derive from this
        public virtual double GetArea() 
        {
            return width * height;
        }

        public bool Is2D() => true;

        public bool Is3D() => false;
    }

    public class Square : MyRectangle
    {
        public Square(double side) : base(side, side)
        {
        }

        public override double GetArea()
        {
            return this.width* this.width;
        }

    }

    public class Blob : IDimension
    {
        public bool Is2D() => false;

        public bool Is3D() => true;
    }

    public class Cube: IDimension, IAreaProvider
    {
        public double GetArea() => 2 * 3 * 4;

        public bool Is2D() => false;

        public bool Is3D() => true;
    }
}
