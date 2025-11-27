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

        public static Price Pounds(double amount)
        {

            return new Price(amount, "GBP");
        }

        public static Price Euros(double amount)
        {

            return new Price(amount, "EUR");
        }

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


}
