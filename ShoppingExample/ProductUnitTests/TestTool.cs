using NUnit.Framework;
using ProductsLib;
using ProductsLib.Tool;

namespace ProductUnitTests
{
    public class TestTool
    {
        private Tools tool;

        [SetUp]
        public void Setup()
        {
            tool = new Hammer("Hammer", "IKA", Price.Pounds(12.5));
        }

        [Test]
        public void Hammer_ShouldBeHandTool()
        {
            Assert.IsTrue(tool.IsHandTool);
        }

        [Test]
        public void Hammer_HasCorrectPrice()
        {
            Assert.That(tool.Price.Amount, Is.EqualTo(12.5));
            Assert.That(tool.Price.Currency, Is.EqualTo("GBP"));
        }

        [Test]
        public void Hammer_HasCorrectNameAndDescription()
        {
            Assert.That(tool.Name, Is.EqualTo("Hammer"));
            Assert.That(tool.Description, Is.EqualTo("IKA"));
        }
    }
}
