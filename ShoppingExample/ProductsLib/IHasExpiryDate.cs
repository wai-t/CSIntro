namespace ProductsLib
{
    // 3. Power tools only work in certain countries because of voltage differences and plug shapes.
    //    How would you represent this in your class design? You need to tell the customer whether
    //    the power tool will work in "UK", "USA/CANADA", "EUROPE", etc.
    // 4. Look at the interface I have specified below for items that have an expiry date, like Food or Vouchers.
    //    Some Foods need to be eaten before expiry date, and Vouchers sometimes need to be used before expiry date.

    public interface IHasExpiryDate
    {
        DateTime ExpiryDate { get; set; }
    }

    // 5. Look at the Vouchers class. Notice it inherits from Product but also implements more than
    //    one interface. This is the big difference between classes and interfaces in C#. If using only
    //    classes, we would have to use single inheritance, which means the structure can only be a tree.
    //    But with interfaces, we can implement multiple interfaces, so the structure can be a graph.
    //    Real life products are more like a graph than a tree!
}
