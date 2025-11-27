namespace ProductsLib.Clothing
{
    public abstract class Clothing : Product
    {
        public Clothing(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }


}
