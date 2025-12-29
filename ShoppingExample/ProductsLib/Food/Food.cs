using ProductsLib.Interfaces;


namespace ProductsLib.Food
{
    public abstract class Food : Product, IHasExpiryDate
    {

        public bool IsGlutenFree { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DietType DietType { get; set; }

        public bool IsExpired => DateTime.Now >= ExpiryDate;
        public Food(string name, string description, Price price , bool isGluteemFree,DietType dietType, DateTime? expiryDate = null)
            : base(name, description, price)
        {

          
            IsGlutenFree = isGluteemFree;
            DietType = dietType;
            ExpiryDate = expiryDate ?? DateTime.MaxValue;

        }

      

    }


}
