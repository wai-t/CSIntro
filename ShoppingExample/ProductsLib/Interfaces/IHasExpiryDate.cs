namespace ProductsLib.Interfaces
{

    public interface IHasExpiryDate
    {
        DateTime ExpiryDate { get; set; }
        bool IsExpired { get; }
    }
}
