## 27 Jan 2025
# Static Typed Languages

C# is a statically typed programming language. In particular, variables are typed as well as objects and they can only be assigned with objects of a compatible type. This is different from JavaScript and Python, which are dynamically typed, where you can assign any object to a variable, and arrays can hold elements of different types (e.g. a mix of numbers and strings). Consequently C# has a more thorough "compile" step before the program can be executed and it will detect errors such as trying to call functions or use variables and types that don't exist. This is an extremely powerful feature when building large software systems. It means it's harder to check in code that doesn't work. In addition, the statically typed property also means that IDEs are able to perform automatic refactoring and template code generation in a very effective way.

# Class Inheritance - Abstract and Virtual
We talked about object oriented programming: classes and inheritance.

When we design a program, we have in mind a model or a set of concepts. This week we wanted to write a program that understands different 2D shapes and how to compute the area of each shape. So in the analysis, we decided it would be natural to think of  Circle Rectangle and Square as suitable classes. 

We know how to calculate an area of each of these and we know what data is needed to calculate it.
- Rectangle: we need a width and a height, and the area is width*height
- Circle: we need a radius, and the area is $\pi$*radius
- Square: we just need the side (i.e. either width or height, it doesn't matter), and the area is side*side
  
So we can write those classes, add fields (width, height, radius, etc) as needed, add a getArea() method to do the area calculation. This is called **cohesion** (or **modularity**), because it gathers together all the data and code that each class needs in one place. And by using **private**, **protected** and **public** modifiers on each member of the class we can make sure that external code cannot access and modify data that we don't want it to see. This is **encapsulation**; each class only see data and code it needs to, and external code only sees data and code it cares about. The principle is that if you are not using something, you can't break if that something changes.

In our example, the external code needs to take these shapes and retrieve the area for each (and just writes it to console). It would be silly to write a new section of code for each shape. We'd just be copying and pasting blocks of code. Even worse, if a new shape, like a Hexagon, is created we would have to update our code. Even more worse, if we didn't know about a new shape someone on the team just developed, the system would probably report an error. This kind of problem is known as too much **coupling**. If a system is made of N parts and each part has a dependency on every other part, there are a $N(N-1)$ dependencies, which doesn't grow in proportion to the size of the program but as $N^2$. Every time you change one component you risk breaking, or at least needing to test $N-1$ other components. So as a system grows its development gets slower and more expensive.

So the object oriented approach is to identify what all these shapes have in common. (The clue is often in the name!) So we create a class called Shape. It contains features that are common to all shapes. In our case, we know that every 2d shape has an area. And because the Shape is the "common" class, we make it the base class of our inheritance hierarchy. The Rectangle, Circle and Square **derive from** (or **inherit from**, or **extend**) the base class. Shape is said to be a **base** class or **superclass** of Rectangle, Circle and Square. And Rectangle, Circle and Square are said to be **subclasses** of Shape.

```
Shape
   ├── Circle
   └── Rectangle
        └── Square
```
Sometimes it isn't obvious in which direction the inheritance should go. A useful rule is to ask whether it is true that "A is a B" or "B is a A". In our case a Circle is a Shape, but a Shape is not a Circle. Similarly, a Square is a (kind of) Rectangle but a Rectangle is not a Square, so we made Square a subclass of Rectangle.

So how does this help us reduce **coupling**? Inheritance allows us to declare a method on Shape (we called it getArea()) which the code can call, but the code that is executed will actually be the getArea() method on the Rectangle, Circle or Square. This means that our calling code only knows about the Shape class. So there is no dependency between the calling code and the Circle, Rectangle and Square classes. As long as our calling code works with Shape, we can change the subclasses or add new one, and our calling code will still work. In other words, we should ask: if we change this, how many other parts of the system will also have to change (i.e. coding time, testing, risk etc).

In C#, we can use the **virtual** modifier on Shape.getArea() (i.e. the base class) to tell the compiler that this isn't necessarily the method we actually want to run when we call it. The **override** modifier is used for subclasses that have their own version of getArea(). When the program runs, the version that is lowest in the inheritance chain is the one that is called. getArea() is called a **virtual function**. In our case, we made Square a subclass of Rectangle and provided a getArea() method which calculated the area by just multiplying the width by itself. So if the Shape that we are processing is a Square then it would call its version of getArea(). Optionally, we could have decided not to provide Square with its own getArea(), and then Rectangle.getArea() would have been called to multiply width by height, and in this case it would give us the same answer. This is not generally be true in other applications, so it's a design decision whether inherited methods need an implementation at each level, and you need to think about whether a class actually needs it's own version of a function or whether code is being repeated unnecessarily.

In the case of our shapes, however, there is one last thing to think about. A Shape isn't a concrete thing; it's an abstract thing because you can't actually calculate its area (without knowing exactly which shape it is). So instead of the **virtual** modifier on Shape.getArea() we used **abstract**. This means that we don't need to write any code for Shape.getArea(); it has an empty body. Furthermore, having an **abstract** method on a class causes the whole class to be **abstract**, meaning that you can't instantiate it using **new**. If we couldn't have abstract classes, there would be a danger that someone could write meaningless code to instantiate one and call getArea() on it. Then we would have to write some code in getArea() that throws an exception to report that something illegal is happening, which would be a waste of everyone's time.

# Summary

- **virtual** - introduces a virtual method **with code** in the base class, which **can** be overridden in subclasses
- **abstract** - introduces a virtual method **without code** in the base class, which **must** be overridden somewhere in each branch of the inheritance tree
- **override** - provides a new version of code for a class which overrides the version in its base class
  
The base class doesn't have to be the top level class. It can be derived from something else, but the function will only be accessible if you have a variable of the type of the base class or one of the subclasses.
The function can also skip a generation, you don't need to provide a version at every level of the hierarchy