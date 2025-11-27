namespace ProductsLib.Clothing
{
    public abstract class WomensClothing : Clothing
    {
        public WomensClothing(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }


}
