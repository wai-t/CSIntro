namespace ProductsLib.Voucher
{
    public class TeaBagVoucher : Vouchers_Manager
    {
        public TeaBagVoucher(string name, string description, Price price, DateTime? expiryDate, bool isDigital = true)
            : base(name, description, price, expiryDate, isDigital)
        {
        }
    }


}
