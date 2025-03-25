using System.Security.Cryptography;
using Xunit;

namespace StructsAndRecords
{
    interface IInterface1 { }

    public class MyClass
    {
        public string? MyProperty { get; set; }

        public MyClass(string? MyProperty = "MyClass Property")
        {
            this.MyProperty = MyProperty;
        }

        public void MyMethod()
        {
            Console.WriteLine($"MyClass {MyProperty}");
        }
    }

    public struct MyStruct
    {
        public string? MyProperty { get; set; }

        public MyStruct(string? MyProperty = "MyStruct Property")
        {
            this.MyProperty = MyProperty;
        }

        public void MyMethod()
        {
            Console.WriteLine($"MyStruct {MyProperty}");
        }
    }


    // This example is just to show that a record is basically
    // a class with some restrictions.
    public record MyRecord
    {
        public MyRecord(string? myProperty = "MyRecord Property")
        {
            MyProperty = myProperty;
        }

        public string? MyProperty { get; set; }
        public void MyMethod()
        {
            Console.WriteLine($"MyRecord {MyProperty}");
        }
    }

    // This is a record with positional parameters, and is the standard way to define a record.
    public record MyValueObject(string Prop1, string Prop2, int Prop3, MyClass Prop4)
    {
        // Methods are not normally defined in records, but it is possible.
        public void MyMethod()
        {
            Console.WriteLine($"MyValueObject {Prop1} {Prop2} {Prop3}");
            Prop4.MyMethod();
        }
    }

    // illegal: class Class1 : MyStruct { }
    // illegal: class Class2 : MyRecord { }
    //
    // illegal: struct Struct2 : MyStruct { }
    // illegal: struct Struct2 : MyClass { }
    // legal to inherit interface struct Struct2 : IInterface1 { }
    // illegal: struct Struct3 : MyRecord { }
    //
    //legal: record Record1: MyRecord { }
    //legal: record Record2 : IInterface1 { }
    //illegal: record Record3 : MyClass { }

    internal class Program
    {
        static void Main(string[] args)
        {
            var c = new MyClass();
            c.MyMethod();
            var c2 = new MyClass();
            Assert.True(c != c2); // Not equal because class is a reference type.
            ClassFunction(c);

            var s = new MyStruct();
            s.MyMethod();
            var s2 = new MyStruct();
            Assert.True(s.MyProperty == s2.MyProperty); // Can't compare structs directly.
            StructFunction(s);

            var r = new MyRecord();
            r.MyMethod();
            var r2 = new MyRecord();
            Assert.True(r == r2); // Records are value types, so they can be compared directly.
            RecordFunction(r);

            var vo = new MyValueObject("Prop1", "Prop2", 3, new MyClass());
            vo.MyMethod();
        }

        static void ClassFunction(MyClass c)
        {
            // The handle of the object is passed to the function
            // and stored on the stack until the function returns.
            // The object itself is on the heap, and is probably
            // shared with other parts of the program.
            c.MyMethod();
        }

        static void StructFunction(MyStruct s)
        {
            // The entire struct is passed to the function
            // and stored on the stack until the function returns.
            // The struct is not shared with other parts of the program.
            s.MyMethod();
        }

        static void RecordFunction(MyRecord r)
        {
            // The handle of the object is passed to the function
            // and stored on the stack until the function returns.
            // The object itself is on the heap, and is probably
            // shared with other parts of the program.
            r.MyMethod();
        }
    }
}
