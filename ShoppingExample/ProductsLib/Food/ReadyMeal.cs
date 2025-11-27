namespace ProductsLib.Food
{
    public class ReadyMeal : Food
    {
        public ReadyMeal(string name, string description, Price price, DateTime? expiryDate = null) : base(name, description, price, expiryDate)
        {

        }
    }


}
