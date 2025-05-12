## 12 May 2025
# Continuing Project Reviews
- Wordle https://github.com/wai-t/combined_wordlist_ali/tree/feedback_wai
- TFL https://github.com/wai-t/TFL_amy/tree/feedback_wai

# Learning advice
We all have to realise that the most important component of learning to program is not about finding the right teaching resources, books, youtube videos, etc, but it is about learning to program by writing programs. I have worked with many skilled programmers who didn't have access to a computer at home. Instead they learned to program by writing their programs down on paper. The reason this works, is because one of the mental challenges in programming is how to translate the problem into a solution that takes the form of an algorithm.

Knowledge of techniques like design patterns and SOLID principles can only be learned in the context of having written lots of programs. These patterns and principles have been developed from a body of industry experience that has been reflected upon to identify what practices work and what practices don't. So it's not enough for a new student to just learn them as a list of facts. They need to be learned in the context of having written real code that exposes the need for good programming practices.

# Homework

Let's do some short projects that give us a reason to write a lot of code quickly. This week think about how you would start at first principles in thinking about the mathematical objects that live in the 2D space of x,y coordinates and translate that into code that represents your knowledge about them.

So the model will start with a point. How is that represented? 
- Maybe a tuple (double x, double y)?

What's a line?
- A pair of points?

What's a shape?
- A collection of lines?

At this point, you will be thinking about the problems that C# throws at you to put you off and confuse you - there's at least 4 different types you can choose from: class, struct, tuple, record. So don't worry about that choice, there's no right or wrong choice for now, so just pick one. You can always refactor later.

What are the rules that these objects must obey?
- a Point has no rules I can think of: x and y can be anything +/0/-, and don't depend on each other
- a Line maybe has only one rule (length>0)
- a Shape has quite a few rules:
  - Each line must be connected to the end of another line, and by following the connections, you trace the lines all the way around the perimeter of the shape.
    - How would this translate into code?
  - A shape has at least 3 sides.
  - The Perimeter of a shape can't cross over itself, it has to go all the way around and separate the interior from the exterior.
    - How would you test for this in code?

How would you enforce these rules in your program? Each type will need some code that reports that a rule has failed. And you will also need to create unit tests to test this code. (Tip: Sometimes, you can design your data structure so that it automatically satisfies some of these rules: think about how to make sure that the lines of a shape join to each other.)

What constructional patterns could you use to allow a developer to use your code to easily create these objects, and protect them from creating invalid ones. Maybe you can design some factory methods, or builders, to build a line from two points, and to build a shape from a collection of lines.

What properties do these objects have that might require code to implement? A Line has a length. A shape has an Area and a Perimeter. Would these be good candidates for a class/struct/record method? These properties will be chance to do some mathematical programming.

Hopefully, you can see that it doesn't take a big example to provide a lot of practice in designing and writing code.

Challenges:
- the obvious choice of type for x,y is a number, e.g. a double. But would any type of number work? What about byte? int?
- Can you write some constructional code to accept two shapes, and test if they overlap?
- Mega-challenge: if two shapes overlap, can you write the method to return the shape(s) that is the intersection/union of them? Does your method return one shape at most, or should it return a list of shapes?