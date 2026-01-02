namespace ProductsLib.MotorVehicles
{
    public abstract class MotorVehicles : Product
    {
        public MotorVehicles(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }


}
