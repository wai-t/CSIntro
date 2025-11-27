using ProductsLib.Interfaces;

namespace ProductsLib.Food
{
    public abstract class Food : Product, IHasExpiryDate
    {
        public Food(string name, string description, Price price, DateTime? expiryDate = null)
            : base(name, description, price)
        {

            ExpiryDate = expiryDate ?? DateTime.MaxValue;
        }


        public DateTime ExpiryDate { get; set; }

        public bool IsExpired => DateTime.Now >= ExpiryDate;
    }


}
