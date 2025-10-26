This is the homework from lesson 2

We learned about *abstract*, *static*, *virtual*, *override* and *new* keywords in lesson 2.

Make a copy of the output of your last homework, which is in [this folder](./Homework1/TypesAndClasses/). Copy it into [Homework2](./Homework2/).

The Shape class and everything that derives from it looks perfect, except for some spelling mistakes and uppercase/lowercase errors. Correct these so that your code follows good coding standards (fields start lowercase, methods and classes start Uppercase, and all names are camel case.)

Now extend your program so that can also represent 3D shapes (like cube and sphere). Rename your Shape class to Shape2D (use the Rename tool). Add a class called Shape3D. Create a new base class called AbstractShape and let Shape2D and Shape3D derive from it.

Add Cube and Sphere to derive from Shape3D. What parameters should the constructors receive?

For every Shape3D, implement methods (remember to use inheritance, abstract and override methods):
- double GetSurfaceArea() (returns the surface area of the 3D shape)
- double GetVolume() (returns the volume of the 3D shape)

On AbstractShape, implement:
- bool Is3D() (returns true for 3D shapes)
- bool Is2D() (returns true for 2D shapes)

Where will you need to implement these, and can you avoid repeating yourself?

It's a good pattern not to require programmers who use your classes to know how your constructors should be called (by using *new*) and instead provide methods like:
- Square CreateSquare(double side)
- Sphere CreateSphere(double radius)

Since you might not have any variables (objects) that you can call these methods on, they will have to be *static* (so that you can call them through the class name). Since, in C# all methods have to be in a class, which class(es) would be a good place to put them? 

Write a method, which prints information about an AbstractShape:
- void PrintShapeInfo( AbstractShape shape);

This should print whether it is 2D or 3D, it's area, perimeter, surface area and volume (as appropriate).







