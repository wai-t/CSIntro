namespace ProductsLib.Clothing
{
    public abstract class MensClothing : Clothing
    {
        public MensClothing(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }


}
