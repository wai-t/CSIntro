using System.Numerics;
using System.Runtime.InteropServices;

namespace TypesAndClasses
{
    internal class Program
    {
        string programName = "Program";

        static void Main(string[] args)
        {
            Console.WriteLine("Types And Classes");

            /**
             * 
             * In javascript, this is legal code (or it might be, but I don't know it very well):
             * let a = "Hello World"; // string
             * a = 1;                 // number
             * a = { "k": 1, "l" : 2};  // object
             * a = [1,2,3,4];           // list
             * a = () => { return 5; }; // function object
             * 
             **/

            string a = "Hello World"; // a is declared.
            // a = 1; iilegal. C# is strongly typed. Variables have a type that never changes
            var b = "Hello World"; // the type of b is "inferred" by the compiler, and it is a string.
            b = a;
            
            var c = 1; // integers only ...-1, 0, +1....
            byte bb = 1; // 8 bits can represent 0 -> 255
            short ss = 1; // 16 bits 0->65535
            int i = 1; // 32 bits 0->2 billion approx
            long l = 1; // 64 bit 0->lots

            ushort us = 1; uint td = 1; 
            
            double d = 1.0; // 64bits floating point. You can have decimals
            float dd = 0.1F; // 32bits (also can say Single)

            System.Console.WriteLine($"{AddNumbers(1,2)}");

            AddNumbers(2, 3);

            JustPrint("twice");

            MyClass cc = new MyClass(2,10);
            cc.id = 2;
            // illegal cc.prot = 3;

            var idtimesx = cc.GetIdTimesX(2);

            MyClass cd = new MyClass(3);
            //          cd.id = 3;

            MyBetterClass better = new MyBetterClass("Joe");

            Shape circle = new Circle();
            Shape square = new Square();
            Shape triangle = new Triangle();

            WriteShape(circle, "circle");
            WriteShape(square, "square");
            WriteShape(triangle, "triangle");
        }

        static void WriteShape(Shape shape, string name)
        {
            Console.WriteLine($"{name} perimeter {shape.Perimeter()}");
        }

        // return-type FunctionName ( Parameter list )
        static int AddNumbers(int first, int second)
        {
            return first + second;
        }

        static void JustPrint(string message) // void means return nothing
        {
            Console.WriteLine(message);
            if (message == "twice")
            {
                Console.WriteLine(message);
                return;
            }
            else
                Console.WriteLine("that's all");
        }

    }

    public class MyClass // MyClass is user-defined type
    {
        public int id; // field (is a "variable" that is a member of a class)
        protected int prot; // protected field means it is visible to the class members;
        private int identifier;// private field means it is visible to the class members;

        public MyClass()
        {
            id = 0;
            prot = 0;
            identifier = 0;
        }

        public MyClass(int identifier) // constructor. Same name as the class name. And doesn't return anything
        {
            this.id = identifier;
            this.prot = identifier + 5;
            this.identifier = identifier;
        }

        public MyClass(int identifier, int secondid) // constructor. Same name as the class name. And doesn't return anything
        {
            this.id = identifier * 100 + secondid;
        }

        public int GetIdTimesX(int x)
        {
            var z = OnlyIAmCleverEnoughToCallThis();
            return x * id;
        }

        protected int OnlyMyFamilyIsCleverEnoughToCallThis()
        {
            return 0;
        }
        private int OnlyIAmCleverEnoughToCallThis()
        {
            return 0;
        }
    }

    public class MyBetterClass : MyClass
    {
        string name;
        public MyBetterClass(string name)
        {
            this.name = name;
            this.id = 77;
            this.prot = 88; // ok because the field is protected.
            // this.identifier = 99; illegal because the field is private
            this.OnlyMyFamilyIsCleverEnoughToCallThis();
        }
    }

    public abstract class Shape
    {
        public abstract double Perimeter();
    }

    public class Triangle : Shape
    {
        double side = 5.0;

        public override double Perimeter()
        {
            return side + side + side;
        }
    }

    public class Circle : Shape
    {
        double radius = 2.0;

        public override double Perimeter()
        {
            return 2.0 * Math.PI * radius;
        }
    }

    public class Square : Shape
    {
        double side = 2.0;

        public override double Perimeter()
        {
            return 4 * side;
        }
    }

    // Homework
    // Add an new method ( double Area()) to Shape and implement for the three shapes
    // Write another method that calculates Area/Perimeter for each Shape. Call it RatioOfAreaAndPerimeter
    // Change the constructors of the shapes so that you can provide the side.
    // Make the Triangle an irregular triangle  (3 sides are different).
    // Make the Square a rectangle instead

}
