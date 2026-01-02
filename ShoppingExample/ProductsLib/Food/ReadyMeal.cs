using System.Data.SqlTypes;

namespace ProductsLib.Food
{
    public class ReadyMeal : Food
    {
        public ReadyMeal(string name, string description, Price price , bool isGlutenfree , DietType dietType, DateTime? expiryDate = null) : base(name, description, price, isGlutenfree, dietType, expiryDate)
        {

        }
    }


}
