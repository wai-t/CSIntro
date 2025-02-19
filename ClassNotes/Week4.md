## 18 Feb 2025
# How to choose between .NET collections and how to make your classes "collectable"

## Performance Testing
We looked at the PerformanceTest project, where we measured how look it took for a LinkedList, List and 
HashSet to insert a number of elements, find them again in a different order, and delete them one at a time. We explored how the performance changes with the number of items we add to the collection. In other words, we tested how the performance **scaled** with volume of data.

We looked at the slides about hashsets, arrays and linked list in [this Powerpoint](https://github.com/wai-t/CompSci/blob/main/ComputerScience/Data_structures/Data%20Structures.pptx) and talked about the pros and cons of each type of collection, and learned the reasons why the perform test results scaled in the way they did.

We found that the HashSet at least matches or outperforms everything else, but its major drawback is that it does not preserve order. Another drawback is that it requires 30% extra memory overhead to maintain performance.

We found that an array (the List is a dynamic array) is good when inserting data at the end of the array, but if we add data at the beginning (using the AddFirst() method), the perform quickly slows down. And similarly, when removing data.

We found that the linked list starts off slightly slower than the List, but it's inserting and deleting performance stays constant and outperforms the List for large amounts of data.

Generally we found that searching for an item in the List and LinkedList are much slower than the HashSet, but we learned that a big improvedment can be achieved by firstly sorting the items and then using a **binary search** method to do the find.

Once you have a mental model of how each data structure works in terms of how data is internally organised and how insert find and delete operations manipulate the data, you will develop a feel for why these data structures perform the way they do.

## Making your classes "collectable"
We moved on to finding out how to store our own custom classes in .NET collections.

In order to perform sorting operations on a class, we can
- implement IComparable<> on the class
- implement an IComparer<> helper class

Implementing IComparable<> can only be done once on a class so it can be used to implement the default sorting order. Multiple IComparer<> helper classes can be implemented if different ways to sort our objects is needed.

In order to store our custom classes in a HashSet, we can
- implement IEquatable<> on the class
- override the Object.GetHashCode() method inherited from the base class.
This enables the HashSet to determine which hash bucket to store each item, and to test whether two items are equal (remember that ISets only allow unique items).

