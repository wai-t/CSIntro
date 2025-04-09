using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace DesignPatterns
{
    public class TestConsoleWriter : TextWriter
    {
        private readonly ITestOutputHelper _output;

        public TestConsoleWriter(ITestOutputHelper output)
        {
            _output = output;
        }

        public override Encoding Encoding => Encoding.UTF8;

        public override void WriteLine(string? value)
        {
            _output.WriteLine(value ?? string.Empty);
        }

        public override void Write(string? value)
        {
            _output.WriteLine(value ?? string.Empty);
        }
    }


}
