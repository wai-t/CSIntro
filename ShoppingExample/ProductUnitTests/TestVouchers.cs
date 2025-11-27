using ProductsLib;
using ProductsLib.Voucher;
using ProductsLib.Clothing;

namespace ProductUnitTests
{
    public class TestVouchers
    {
        private TeaBagVoucher voucher;

        [SetUp]
        public void Setup()
        {
             voucher = new TeaBagVoucher("Teabags", "Half Price Tea", Price.Pounds(1.50), new DateTime(2025, 12, 31), false);
        }

        [Test]
        public void TestNewTeabagVoucher()
        {

            Assert.That(voucher, Is.Not.Null);
            Assert.That(voucher.Name, Is.EqualTo("Teabags"));

        }

        [Test]
        public void TestNewTeabagVoucherExpiryDate()
        {

            Assert.That(voucher, Is.Not.Null);
            Assert.That(voucher.ExpiryDate, Is.EqualTo(new DateTime(2025,12,31)));
            Assert.That(voucher.IsExpired, Is.False); // Not a good test because it will fail after some time.

        }

    }
}