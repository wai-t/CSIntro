using ProductsLib.Interfaces;
using System.Diagnostics;
using System.Xml.Linq;


namespace ProductsLib.Food
{
    public abstract class Food : Product, IHasExpiryDate
    {

        public bool IsGlutenFree { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DietType DietType { get; set; }
        public int CaloriesPerUnit { get; set; }
        public int FatPerUnit { get; set; }
        public int SugarPerUnit { get; set; }

        public bool IsExpired => DateTime.Now >= ExpiryDate;
        public Food(string name, string description, Price price, bool isGluteemFree, DietType dietType, int caloriesPerUnit, int fatPerUnit, int sugarPerUmit, DateTime? expiryDate = null)
            : base(name, description, price)
        {

            if (caloriesPerUnit < 0)
            {
                throw new ArgumentOutOfRangeException("Calory Cannot be nagative");
            }
            if (fatPerUnit < 0)
            {
                throw new ArgumentOutOfRangeException("Fat Cannot be nagative");
            }
            if (sugarPerUmit < 0)
            {

                throw new ArgumentOutOfRangeException("Sugar Cannot be nagative");
            }

            IsGlutenFree = isGluteemFree;
            DietType = dietType;
            CaloriesPerUnit = caloriesPerUnit;
            FatPerUnit = fatPerUnit;
            SugarPerUnit = sugarPerUmit;
            ExpiryDate = expiryDate ?? DateTime.MaxValue;


        }



    }


}
