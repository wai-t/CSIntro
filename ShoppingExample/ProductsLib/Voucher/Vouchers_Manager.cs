using ProductsLib.Interfaces;
using ProductsLib;


namespace ProductsLib.Voucher
{
    public abstract class Vouchers_Manager : Product, IHasExpiryDate, IPhysicalOrDigital
    {
        public Vouchers_Manager(string name, string description, Price price, DateTime? expiryDate, bool isDigital = true)
            : base(name, description, price)
        {
            IsDigital = isDigital;
            ExpiryDate = expiryDate ?? DateTime.MaxValue;
        }

        public DateTime ExpiryDate { get; set; }

        public bool IsDigital { get; init; }

        public bool IsExpired => DateTime.Now >= ExpiryDate;
    }


}
