## 25 Feb 2025
# Binary search trees
We covered lists (arrays and linked lists) and hash sets last week. This week we moved
on to talk about binary search trees. The reason it is named this way is because of its definition:
 - **tree**: the structure is made up of items (nodes) arranged in a parent-child hierarchy, with a single "root" node at the top, and each child has exactly one parent.
 - **binary**: each parent has at most 2 children (a left and a right).
 - **search**: the left child (and all of it's children, and grand children, etc) has a key less than the key of its parent. The right child (...) has a key greater than the key of its parent.
  
As items are added or removed from the tree, it maintains the order by making sure that that item is placed in the correct position, which may require some rearrangement of the tree during each operation. For this reason, insert/delete operations are $O(logN)$, so it is slower than a hash set, but has the key advantage that it maintains sort order of the collection. 

## Sorted collections in System.Collections.Generic
We added the sorted collections to the PerformanceTest project and measured timings for insert, find, delete operations. We also tested the dictionary (a.k.a table, a.k.a. javascript "object") style of collections which contain items that consist of key/value pairs: SortedDictionary and SortedList.

 - **SortedSet** is like the **HashSet** but is based on a binary search tree rather than a hash set. With the $O(logN)$ performance for insert, find and remove, it is consistently slower than the hash set, but it maintains the order of the collection and the tree uses memory more efficiently. This use case is very common and is the reason why hash set is not used all the time when find is an important requirement.
 - **SortedDictionary** is a **SortedSet** that contains key/value pairs. We saw that the performance is similar, but slightly slower because each node has more data.
 - **SortedList** is not a binary search tree at all. Instead the items are stored in an array which is kept in order. So every time an item is inserted, it needs to find the right place to insert it, and move the items above it to make room for it. We saw that inserting and deleting was slower than for the tree and hash set based collections.

## About the MakeTestData data factory
The function *IEnumerable<long> MakeTestData(long size)* is written so that it doesn't create an array of *size* elements internally, but instead it returns an IEnumerable interface which generates the next random number on demand returning it through a *yield return* statement. It is **deferring** work until the point where it is needed. This is an important principle when developing functions that generate large amounts of data. The caller might only end up using a small amount of the data, or it might be able to work in a way where it can work on the items one at a time and not have to keep large amounts of data in memory at the same time. By deferring the work of generating the data in advance, and using up memory to store it, *MakeTestData* leaves it up to the caller to decide how much work and memory is actually consumed. In our main program, we ended up creating a physical array by calling *.ToArray()* on the returned object from *MakeTestData*, because we needed to perform a *Shuffle()* and the only way to do this is to have the whole data set in memory.

## LINQ
We looked at an example of using LINQ which is an SQL like query language for .NET collections. LINQ doesn't do anything that the extension methods of Enumerable does, but it can be more readable, since it doesn't involve anonymous functions with arbitrarily chosen variable names, and chained function calls. However, using the extension methods does make it clearer the logical order of processing steps that the data passes through so it can be easier to spot optimal processing order. Both LINQ and the extension methods implement deferred processing.