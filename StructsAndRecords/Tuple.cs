using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructsAndRecords
{
    internal class TestTuple
    {

        public ( int N, double, string, TestTuple) Method()
        {
            return (1, 1.1, "ijoeij", new TestTuple());
        }

        public void UseTheTuple()
        {
            var tuple = Method();
            Console.WriteLine($"Item1: {tuple.Item1}");
            Console.WriteLine($"Item1: {tuple.N}");
            Console.WriteLine($"Item2: {tuple.Item2}");
            Console.WriteLine($"Item3: {tuple.Item3}");
            Console.WriteLine($"Item4: {tuple.Item4}");
        }

        public void Deconstruct(out int P, out double Q, out string R, out TestTuple S)
        {
            P = 1;
            Q = 1.1;
            R = "ijoeij";
            S = new TestTuple();
        }

        public void UseDeconstruct()
        {
            var c = new TestTuple();

            // N.B not a tuple
            (int P, double Q, string R, TestTuple S) = c;
            Console.WriteLine($"Item1: {P}");
            Console.WriteLine($"Item2: {Q}");
            Console.WriteLine($"Item3: {R}");
            Console.WriteLine($"Item4: {S}");
        }
    }
}
