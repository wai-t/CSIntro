namespace ProductsLib.Electronics
{
    public abstract class Electronics : Product
    {
       
        public Electronics(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }


}
