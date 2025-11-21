using System;
using System.Reflection.Metadata.Ecma335;
using ProductsLib;

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
// it's abstract. Why?   Answer : 
// Product has a Price, a Name, a DescriptionW
//
