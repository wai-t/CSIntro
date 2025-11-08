using System;

class Program
{
    static void Main(string[] args)
    {
        var mansShirt = new MansShirt(
            "FormalShirt",
            "Smart white shirt for business meetings",
            Price.Pounds(25.0)
            );

        var laptop = new Laptop(
            "SuperFastLaptop",
            "Lightweight laptop with powerful performance",
            Price.Euros(999.99)
            );

        // Homework: create more products of different types, priced in different currencies,
        // and some power tools that work in different countries

        Product[] products = new Product[] { mansShirt, laptop };
        DisplayProducts(products);

        DisplayProductsThatArePricedInEuros(products);
        DisplayPowerToolsThatWorkInUSA(products);
        DisplayTheMostExpensiveProduct(products);
    }

    private static void DisplayProducts(Product[] products)
    {
        foreach (var product in products)
        {
            Console.WriteLine($"Product: {product.Name}");
            Console.WriteLine($"Description: {product.Description}");
            Console.WriteLine($"Price: {product.Price.Amount} {product.Price.Currency}");
            Console.WriteLine();
        }
    }
    private static void DisplayProductsThatArePricedInEuros(Product[] products)
    {
        Console.WriteLine("You can buy these products with Euros:");
    }

    private static void DisplayPowerToolsThatWorkInUSA(Product[] products)
    {
        Console.WriteLine("You can buy these power tools that work in USA:");
    }

    private static void DisplayTheMostExpensiveProduct(Product[] products)
    {
        Console.WriteLine("This is the most expensive product on sale");
    }

}

// Product is something we can buy/sell
// it's abstract. Why?
// Product has a Price, a Name, a Description
//
public abstract class Product
{
    // Homework: Name, Description, Price are properties. Find out about this, and learn how
    // a property combines a field and a method. Also, find out what "init" means here.
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
// might be called many times. It's a small object though (how many bytes?)
// so what is the best way to represent it? a stack object or a heap object?
public struct Price
{
    public double Amount { get; init; }
    public string Currency { get; init; }
    private Price(double amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    // Homework: how does the factory method pattern help you to make
    // sure that Price objects are always created correctly with currency names that are valid?
    public static Price Pounds(double amount)
    {
        // Homework, throw exception if amount is negative
        return new Price(amount, "GBP");
    }

    public static Price Euros(double amount)
    {
        // Homework, throw exception if amount is negative
        return new Price(amount, "EUR");
    }

    // Homework: add more factory methods for other currencies like USD, CAD, AUD, JPY, etc.

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
        // Homework: what does this line do? What does "??" mean?
        ExpiryDate = expiryDate ?? DateTime.MaxValue;
    }

    // Homework: notice that the ExpiryDate property was declared on the
    // interface and has to be implemented here (just like abstract methods)
    public DateTime ExpiryDate { get; set; }
}
public abstract class Tools : Product
{
    public Tools(string name, string description, Price price)
        : base(name, description, price)
    {
    }
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

    public bool IsDigital { get; init ; }
}   
public abstract class Vouchers : Product, IHasExpiryDate, IPhysicalOrDigital
{
    public Vouchers(string name, string description, Price price, DateTime? expiryDate, bool isDigital = true)
        : base(name, description, price)
    {
        IsDigital = isDigital;
    }

    // Homework: implement this property from the interface
    public DateTime ExpiryDate { 
        get => throw new NotImplementedException(); 
        set => throw new NotImplementedException(); 
    }
    public bool IsDigital { get; init; }
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
// 2. Tools can be power tools or hand tools. Create classes for these. Abstract or not?
// 3. Power tools only work in certain countries because of voltage differences and plug shapes.
//    How would you represent this in your class design? You need to tell the customer whether
//    the power tool will work in "UK", "USA/CANADA", "EUROPE", etc.
// 4. Look at the interface I have specified below for items that have an expiry date, like Food or Vouchers.
//    Some Foods need to be eaten before expiry date, and Vouchers sometimes need to be used before expiry date.

public interface IHasExpiryDate
{
    DateTime ExpiryDate { get; set; }
}

// Vouchers and Services can be provided physically or digitally, so they implement this interface
public interface IPhysicalOrDigital
{
    bool IsDigital { get; init; }
}

// 5. Look at the Vouchers class. Notice it inherits from Product but also implements more than
//    one interface. This is the big difference between classes and interfaces in C#. If using only
//    classes, we would have to use single inheritance, which means the structure can only be a tree.
//    But with interfaces, we can implement multiple interfaces, so the structure can be a graph.
//    Real life products are more like a graph than a tree!