using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructsAndRecords
{
    internal class AnonymousClass
    {
        // class ThinkOfAName {...}
        public void Method()
        {
            List<int> data = new List<int>() { 1, 2, 3, 4, 5 };

            var result = data.Select(x => new //ThinkOfAName()
            {
                Number = x,
                Square = x * x,
                Cube = x * x * x
            });

            foreach (var item in result)
            {
                Console.WriteLine($"Number: {item.Number}, Square: {item.Square}, Cube: {item.Cube}");
            }


            var result2 = data.Select(x => new  //ThinkOfAName()
            {
                Number = x,
                Square = x * x,
                Cube = x * x * x
            });

            result = result2;
        }
    }
}
