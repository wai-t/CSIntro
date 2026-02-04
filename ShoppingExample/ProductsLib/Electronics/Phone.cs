namespace ProductsLib.Electronics
{
    public class Phone : Electronics
    {
        public String Brand { get; set; }
        public MobileOsType MobileOsType { get; set; }
        public int RamMemory { get; set; }

        public int StorageCapacity { get; set; }

        public bool DualSim { get; set; }

        public int PhoneWeight { get; set; }

        public Phone(string name, string description, Price price, string brand, MobileOsType mobileostype, int ramemory, int storagecapacity, bool dualsim, int phoneweight)
            : base(name, description, price)
        {

            Brand = brand;
            MobileOsType = mobileostype;
            RamMemory = ramemory;
            StorageCapacity = storagecapacity;
            DualSim = dualsim;
            PhoneWeight = phoneweight;

        }
    }


}
