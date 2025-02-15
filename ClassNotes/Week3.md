## 13 Feb 2025
# Generics, Contravariance, Covariance, Collections

## Generics
We talked about **generics** which are classes and functions that use parametrised type arguments, like MyGeneric\<T>.

In contrast to inheritance, where base classes and interfaces are used to model objects of different types which have something in common through an "is a" relationship or "has a feature/capability" relationship, generics are used to model **common algorithms or computations** which can be used on objects of different types. This is why the .NET collections classes are generics. They model operations that you can perform on a set of unspecified items, like sorting and searching, without making any assumptions about what those items are. **Making no assumptions means that they will work with most items and are more immune to changes in those items**. This is good design by reducing dependencies.

However, while implementing the Prism<T> challenge, we discovered that it was necessary to use the "where T: IAreaProvider"
qualifier to specify that our generic can only be used for classes that implement IAreaProvider. The reason this constraint is needed is because in the code for Prism<T>
we needed to call the GetArea() method which is defined in the IAreaProvider interface.
This introduces a dependency and is therefore a weakness in our design. Generally, it's
ideal if we can avoid contraints on type parameters altogether, but it's often unavoidable, and in that case it's best practice to constrain on a very base class or interface. The .NET System.Collections.Generics packages are good examples of this type of design.

## Covariance, Contravariance
We moved on to talk about **contravariance and covariance** in type parameters, and I couldn't come up with a very useful example to show why this is a valuable concept. Since the class, I managed to create an example in [The Shapes.CoContraVariance](../Shapes/CoContraVariance/) project. Here, I reused the Shapes example:
```
Shape
   ├── Circle
   └── Rectangle
        └── Square
```
To illustrate the use of convariant and contravariant type parameters, I create a **MyRectangleCollection** which is a class that holds a collection of **Rectangles** (and therefore also **Squares**). This class has an **Add(IShapeFactory\<>)** method which accepts a class that creates a shape and adds it to the collection, and a **Magnify(IResizer\<>)** method which accepts a class that changes the size of the shapes in the collection.

For **IShapeFactory\<out U>**, I have defined it as a covariant interface which has a MakeShape() method that returns a type U. Because this is covariant, if I implement the interface for a derived class as **IShapeFactory\<Square>**, then I can also use it (by casting) wherever the interface for a base class is needed, e.g. **IShapeFactory\<Rectangle>**. The reason this works is because the type U is only used for outputs from methods, so when the method returns a type of the Derived class, it is legal to cast it to the Base class. Notice that if I try to pass an **IShapeFactory\<Circle>** to **Add()**, the compiler says it is illegal, because Circle is not derived from Rectangle. This is static type safety and ensures we can't insert illegal objects into the collection.

To change the size of the shapes, I defined a contravariant interface **IResizer\<in T>** which has a method **Resize(T target)** which accepts a **T** as input. Notice that the interface doesn't dictate how the resize will be done. That is decided by the class I write to implement the interface, **ShapeMagnifier**. In this case, I decided it should scale the shape in both dimensions by calling the **Shape.Scale()** method, but I can easily create other implementations of IResizer, e.g. that only stretch the shape in one dimension, without affecting existing code. Furthermore, **Shape.Scale()** is an abstract method so the actual resizing calculation is done in the implementation of the derived classes. This combines the practice of **abstraction, encapsulation, and cohesion** in our design. Because **ShapeMagnifier** only calls the base **Shape.Scale()**, it implements the interface using the base class like this, **IResizer\<Shape>**, and because it needs no knowledge of how to do the resizing we should be able to use **ShapeMagnifier** with any class that is derived from **Shape**.

Our MyRectangleCollection class is statically typed to contain **Rectangle** objects and we can call the **Magnify(IResizer<Rectangle>)** method to pass the **ShapeMagnifier**. Because **ShapeMagnifier** has type **IResizer<Shape>** a contravariant cast takes place. It looks like we are trying to cast from a base class to a more derived class, but this is not true when we take a closer look. Within the **Magnify** method, we are taking objects of type **Rectangle** and expecting to pass them into a **Resize()** method on magnifier that accepts **Rectangle**. However, the magnifier at runtime actually has a **Resize** method that accepts **Shape**, so this is perfectly legal as the cast is to a less derived class. But note that it is illegal to pass an **IResizer\<Square>** to the Magnify method because this would require a cast from Rectangle to Square. Again, type safety protects the program from attempting to apply logic to a general class that applies only to a specialised class.

### Summary

**use \<out U>** to mark **covariance**, where you will need to cast IInterface<Derived> to IInterface<Base>

**use \<in T>** to mark **contravariance**, where you will need to cast IInterface<Base> to IInterface<Derived>

The use of generics has allowed us to reduce coupling and dependencies. The **Shape** classes have no dependencies on any of the factory or resizing code. They can be developed and tested independently. Similarly the **IShapeFactory** and **IResizer** generic interfaces have no explicit dependencies on **Shape** because the type is parameterised, and it is possible to implement different logic for entirely different class libraries using the same interface. So the Shapes model and the factory and resizer interfaces can be changed independently. The implementation of the interfaces needs to exploit the Shapes model because that is where the business logic will need to be implemented.

## .NET Collections

We looked that the hierarchy of interfaces in .NET collections.
```
IEnumerable
 └ ICollection
   ├── IList
   ├── ISet
   └── IDictionary
```
The hierarchy progressively adds features to the collection. With an **IEnumerable** it only supports the notion that the collection has a way for the client code to iterate each item in the collection one at a time. It is not even required for the **IEnumerable** to know the count of items. It's a barebones enumerable type.

**ICollections** expands on that by specifying methods to Add, Remove, Count, etc. but not much else. 

With **IList** comes the notion of order, which means that the items have a stable numbered position with the collection, so items can now be retrieved, removed, and inserted by index position. Microsoft takes this further to recommend that an IList should also be a contiguous array which ensures that these methods of access are efficient.

With **ISet** comes the notion of identity. Each item is the set has an id which is the means by which it can be accessed and removed. Items must be unique.

**IDictionary** extends on **ISet** (but not via inheritance) by adding an associated value to each item (which is now referred to as a key) in the set.

We finally looked at some extension methods in the **Enumerable** class which perform database like operations like sorting (**OrderBy**), filtering (**Where**) and aggregation (**Sum**), and looked at the way they generally reference the base interface, which minimises dependency and coupling, and allows the methods to be used for different types of collection classes without the need for customising code. The extension methods are suited to a style of programming called Method Chaining where the IEnumerable interface is used for input and return type, and allows sequences of data operations to be put together in a succinct way. We also talked about deferred processing whereby the execution of queries is delayed until the results are actually known to be required.