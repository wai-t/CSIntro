namespace ProductsLib
{
    public abstract class Tools : Product
    {
        public Tools(string name, string description, Price price)
            : base(name, description, price)
        {
        }

        public abstract bool IsHandTool { get; }
    }

    public class Hammer : Tools
    {
        public Hammer(string name, string description, Price price) : base(name, description, price)
        {


        }
        public override bool IsHandTool => true;


    }



    public class Blender : Tools
    {

        public Blender(string name, string description, Price price) : base(name, description, price)
        {

        }

        public override bool IsHandTool => false;
    }
}
