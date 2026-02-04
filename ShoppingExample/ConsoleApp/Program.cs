using System;
using System.Reflection.Metadata.Ecma335;
using ProductsLib;
using ProductsLib.Clothing;
using ProductsLib.Electronics;

class Program
{
    static void Main(string[] args)
    {
        var mansShirt = new MansShirt(
            "FormalShirt",
            "Smart white shirt for business meetings",
            Price.Pounds(25.0),
            "Leather",
            "Winter",
            true,
            "M&S",
            ClothingCategory.Uniform,
            "India",
            ClothingSize.Small
             );

        var laptop = new Laptop(
            "SuperFastLaptop",
            "Lightweight laptop with powerful performance",
            Price.Euros(999.99)
            );

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
