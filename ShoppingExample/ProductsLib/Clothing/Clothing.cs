
namespace ProductsLib.Clothing
{
    public abstract class Clothing : Product
    {  
        public string Material { get; set; }
        public string Season { get; set; }
         public bool HandWashOnly { get; set; }

        //public Clothing(string name, string description, Price price)
        //     : base(name, description, price)
        //{ }

        public Clothing(string name, string description, Price price , string material , string  season , bool handwashonly)
            : base(name, description, price)
        {

            Material = material;
            Season = season;
            handwashonly = true;

        }
    }


}
