
namespace ProductsLib.Clothing
{
    public abstract class Clothing : Product
    {
        public string Material { get; set; }
        public string Season { get; set; }
        public bool HandWashOnly { get; set; }
        public string Brand { get; set; }
        public ClothingCategory ClothingCategories { get; set; }
        public string CountryOfOrigin { get; set; }
        public ClothingSize Size { get; set; }




        public Clothing(string name, string description, Price price, string material, string season, bool handwashonly, string brand,ClothingCategory clothingcategory, string countryoforigin, ClothingSize size)
            : base(name, description, price)
        {

            Material = material;
            Season = season;
            HandWashOnly = true;
            Brand = brand;
            ClothingCategories = clothingcategory;
            CountryOfOrigin = countryoforigin;
            Size = size;
            

        }
    }


}
