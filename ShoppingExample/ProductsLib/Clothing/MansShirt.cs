namespace ProductsLib.Clothing
{
    public class MansShirt : MensClothing
    {
        //public MansShirt(string name, string description, Price price)
        //    : base(name, description, price, "", "", false)
        //{
        //}
        public MansShirt(string name, string description, Price price, string material, string season, bool handwashonly, string brand, ClothingCategory clothingcategory, string countryoforigin, ClothingSize size)
            : base(name, description, price, material, season, handwashonly, brand, clothingcategory, countryoforigin, size)
        {
        }
    }


}
