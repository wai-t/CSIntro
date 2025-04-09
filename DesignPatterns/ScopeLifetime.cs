using DesignPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns
{
    internal class ConstructableClass
    {
        public ConstructableClass()
        {
            // instance constructor is called when new ConstructableClass() is called
        }

        static ConstructableClass()
        {
            // static ctor is called once when the type is used for the first time
            Console.WriteLine("Static constructor ConstructableClass called");
        }

        private int _value; // instance field. Every instance of the class has its own copy of this field
        private static int _staticValue; // static field. All instances of the class share this field

        //properties can also be instance or static
        public int InstanceProperty { get; set; }
        public static int StaticProperty { get; set; }

        public void InstanceMethod()
        {
            // An instance method works in the context of an instance of the class
            // so it has access to instance fields/props and static fields/props
            // you use **this** to access an instance field/prop, and the class name to access a static field/prop
            Console.WriteLine($"Instance method called. InstanceProperty = {this.InstanceProperty}, StaticProperty = {ConstructableClass.StaticProperty}");
        }

        public static void StaticMethod()
        {
            // A static method works in the context of the class itself, not an instance of the class
            // so it has access to static fields/props only
            // you use the class name to access a static field/prop
            Console.WriteLine($"Static method called. StaticProperty = {ConstructableClass.StaticProperty}");
        }

    }

    static internal class StaticClass
    {
        // static class cannot be instantiated, and cannot have instance members
        // all members of a static class are static
        // static classes are sealed, so they cannot be inherited from
        // static classes are used to group related methods and properties together
        public static void StaticMethod()
        {
            Console.WriteLine("Static method called");
        }
    }
}

public class Tester
{
    public readonly ITestOutputHelper _output;

    public Tester(ITestOutputHelper output)
    {
        _output = output;
        Console.SetOut(new TestConsoleWriter(output));
    }
    [Fact]
    public void TestConstructableClass()
    {
        // static constructor is called when the type is used for the first time
        var instance = new ConstructableClass();
        var instance2 = new ConstructableClass(); // static constructor is not called again

        instance.InstanceProperty = 5; // sets the instance property
        instance2.InstanceProperty = 10; // sets the instance property of a different instance

        instance.InstanceMethod(); // calls the instance method
        instance2.InstanceMethod(); // calls the instance method

        ConstructableClass.StaticProperty = 10; // sets the static property
        instance.InstanceMethod(); // calls the instance method
        instance2.InstanceMethod(); // calls the instance method

        ConstructableClass.StaticMethod(); // calls the static method
    }

    [Fact]
    public void ScopeAndLifetimeDemo()
    {
        // All classes in this file, and project are in scope for this method
        // but not necessarily accessible because that depends on the access modifier

        var i = 1; // i is in scope for this code block only.
                   // It's lifetime is from here until the closing }

        ConstructableClass? c = null;
        {
            var j = 2; // j is in scope for this code block only.
                       // It's lifetime is from here until the closing  }

            ConstructableClass? d = new ConstructableClass(); // d is in scope for this code block only.
                                                             // it's lifetime is from here until the closing }
                                                             // The class instance is stored on the heap.

            for (var k = 0; k < 10; k++)
            {
                // k is in scope for this code block only.
                // It's lifetime is from here until the closing }

                var l = 3; // l is in scope for this code block only.
                           // It's lifetime is from here until the closing  }
                           // l is recreated every time the loop runs
                ConstructableClass e = new ConstructableClass(); // the class instance is stored on the heap
                                                                 // and will be disposed at the end of the loop
            }

            c = d;
            d = null; // d is no longer in scope, but the instance is still on the heap, because of c.
        }
    } // c goes out of scope and the class instance is disposed.
}
