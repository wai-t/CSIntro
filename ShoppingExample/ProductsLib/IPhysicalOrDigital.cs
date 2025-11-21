namespace ProductsLib
{
    // Vouchers and Services can be provided physically or digitally, so they implement this interface
    public interface IPhysicalOrDigital
    {
        bool IsDigital { get; init; }
    }

}
