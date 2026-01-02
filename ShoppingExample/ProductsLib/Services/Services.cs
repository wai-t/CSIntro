using ProductsLib.Interfaces;

namespace ProductsLib.Services
{
    public abstract class Services : Product, IPhysicalOrDigital
    {
        public Services(string name, string description, Price price, bool isDigital = false)
            : base(name, description, price)
        {
            IsDigital = isDigital;
        }

        public bool IsDigital { get; init; }
    }


}
