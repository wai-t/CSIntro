using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProductsLib
{
    public abstract class Product
    {
        // Homework: Name, Description, Price are properties. Find out about this, and learn how
        // a property combines a field and a method. Also, find out what "init" means here.  answer : Done.
        public string Name { get; init; }
        public string Description { get; init; }
        public Price Price { get; init; }
        public Product(string name, string description, Price price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }


    // We want to sell our products to many countries, so
    // Price needs both a number and a currency.
    // We might be using Price a lot in many functions and these functions
    // might be called many times. It's a small object though (how many bytes? 8 + 8 = 16 bytes)
    // so what is the best way to represent it? a stack object or a heap object?    I need to explain something for you here so I answer when we tslk sbout it.
    public struct Price
    {
        public double Amount { get; init; }
        public string Currency { get; init; }
        private Price(double amount, string currency)
        {

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount Can not be negative number");
            }


            Amount = amount;
            Currency = currency;
        }
        // Homework: how does the factory method pattern help you to make
        // sure that Price objects are always created correctly with currency names that are valid?
        public static Price Pounds(double amount)
        {
            // Homework, throw exception if amount is negative

            // answer : fisrt I put the if condition here ,I mean  I declare it in each factory methodd in pound , Euros ,...
            //  then I realised that I  repated  many times and its not good , so I decided to removee it and put it in the constractor

            return new Price(amount, "GBP");
        }

        public static Price Euros(double amount)
        {
            // Homework, throw exception if amount is negative :
            // answer : fisrt I put the if condition here ,I mean  I declare it in each factory methodd in pound , Euros ,...
            //  then I realised that I  repated  many times and its not good , so I decided to removee it and put it in the constractor
            return new Price(amount, "EUR");
        }


        // Homework: add more factory methods for other currencies like USD, CAD, AUD, JPY, etc.

        public static Price USD(double amount)
        {

            return new Price(amount, "USD");
        }


        public static Price CAD(double amount)
        {

            return new Price(amount, "CAD");

        }
        public static Price AUD(double amount)
        {
            return new Price(amount, "AUD");
        }


    }

    // The first layer of derived classes are high level categories like
    // Electronics, Clothing, Food, Tools, Motor Vehicles even Services and Vouchers
    // These are still abstract classes because we can't create one without knowing
    // exactly what it is
    public abstract class Electronics : Product
    {
        public Electronics(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }
    public abstract class Clothing : Product
    {
        public Clothing(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }
    public abstract class Food : Product, IHasExpiryDate
    {
        // Homework: what does "DateTime? expiryDate = null" mean?
        public Food(string name, string description, Price price, DateTime? expiryDate = null)
            : base(name, description, price)
        {
            // Homework: what does this line do? What does "??" mean? :  if we have a time it assign our time to ExpryDate
            // otherwise it put 31 December 9999 23:59
            ExpiryDate = expiryDate ?? DateTime.MaxValue;
        }

        // Homework: notice that the ExpiryDate property was declared on the
        // interface and has to be implemented here (just like abstract methods)
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired => DateTime.Now >= ExpiryDate;
    }
    public abstract class MotorVehicles : Product
    {
        public MotorVehicles(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }
    public abstract class Services : Product, IPhysicalOrDigital
    {
        public Services(string name, string description, Price price, bool isDigital = false)
            : base(name, description, price)
        {
            IsDigital = isDigital;
        }

        public bool IsDigital { get; init; }
    }
    public abstract class Vouchers : Product, IHasExpiryDate, IPhysicalOrDigital
    {
        public Vouchers(string name, string description, Price price, DateTime? expiryDate, bool isDigital = true)
            : base(name, description, price)
        {
            IsDigital = isDigital;
            ExpiryDate = expiryDate ?? DateTime.MaxValue;
        }

        // Homework: implement this property from the interface
        public DateTime ExpiryDate { get; set; }

        public bool IsDigital { get; init; }

        public bool IsExpired => DateTime.Now >= ExpiryDate;
    }

    public class TeaBagVoucher : Vouchers
    {
        public TeaBagVoucher(string name, string description, Price price, DateTime? expiryDate, bool isDigital = true) 
            : base(name, description, price, expiryDate, isDigital)
        {
        }
    }

    //
    // In clothing, we have Mens and Womens (still abstract!)
    //
    public abstract class MensClothing : Clothing
    {
        public MensClothing(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }
    public abstract class WomensClothing : Clothing
    {
        public WomensClothing(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }

    // Finally, we have concrete classes that we can instantiate
    // For example, in MensClothing, we have Shirts and MansTrousers
    // and in Electronics we have Phones and Laptops
    public class MansShirt : MensClothing
    {
        public MansShirt(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }
    public class MansTrousers : MensClothing
    {
        public MansTrousers(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }
    public class Phone : Electronics
    {
        public Phone(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }
    public class Laptop : Electronics
    {
        public Laptop(string name, string description, Price price)
            : base(name, description, price)
        {
        }
    }
    // Homework
    // 1. Add more concrete product classes like WomensClothing, Food items, Motor Vehicles
    public class WomenClothing : Clothing
    {
        public WomenClothing(string name, string description, Price price) : base(name, description, price)
        {

        }
    }


    //BIG QUESTION i NEED TO ASK 
    public class ReadyMeal : Food
    {
        public ReadyMeal(string name, string description, Price price, DateTime? expiryDate = null) : base(name, description, price, expiryDate)
        {

        }
    }

    public class Hunday : MotorVehicles
    {
        public Hunday(string name, string description, Price price) : base(name, description, price)
        {

        }
    }


    // 2. Tools can be power tools or hand tools. Create classes for these. Abstract or not?

   

    // 5. Look at the Vouchers class. Notice it inherits from Product but also implements more than
    //    one interface. This is the big difference between classes and interfaces in C#. If using only
    //    classes, we would have to use single inheritance, which means the structure can only be a tree.
    //    But with interfaces, we can implement multiple interfaces, so the structure can be a graph.
    //    Real life products are more like a graph than a tree!
}
