namespace ProductsLib.Clothing
{
    public abstract class MensClothing : Clothing
    {
        public MensClothing(string name, string description, Price price , string material , string season , bool handwashonly)
            : base(name, description, price ,material , season , handwashonly)
        {
        }
    }


}
