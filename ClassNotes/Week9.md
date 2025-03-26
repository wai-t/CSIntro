## 25 Mar 2025
# Review of Projects
## TFL feedback
Model fields, generally use the required modifier unless the field is optional in the json.
Remember that this is an external model (TFL controls it) so we shouldn't "add" any more to
it. Allowing a field to be null when it isn't or providing a default value, permits error
situations which might need to be checked later. Better to fail early than late. We'll
talk about error handling in a bit.
Use [Tfl swagger json](https://api.tfl.gov.uk/swagger/docs/v1) to check the model

Error checking:
Decide between returning an error status, a default value, or throwing an error

Would probably throw errors here instead of returning a default value:
https://github.com/Ameneh-Keshavarz/TFL/commit/f52e86e46b0ec8aa7ecd03cc65c44d8544989bcd#diff-3080a98cbfec4d20b6ec94e6c8c1caa6eb90f9357bdc18ab2438931466c3f6a0L31
https://github.com/Ameneh-Keshavarz/TFL/commit/f52e86e46b0ec8aa7ecd03cc65c44d8544989bcd#diff-187d3cf7eed834e00314d07b924e1a1e620a52636d1d2f406a3c2eef8e78dc5cR31

Probably ok to do this, but client would have to know how to handle the null return (up to you):
https://github.com/Ameneh-Keshavarz/TFL/commit/f52e86e46b0ec8aa7ecd03cc65c44d8544989bcd#diff-3080a98cbfec4d20b6ec94e6c8c1caa6eb90f9357bdc18ab2438931466c3f6a0L40

Autocomplete. It might be wise to insist on a minimum query string length (at least 3) before sending a
query to Tfl here (reduces traffic and easier to handle in the UI):
https://github.com/Ameneh-Keshavarz/TFL/commit/f52e86e46b0ec8aa7ecd03cc65c44d8544989bcd#diff-3080a98cbfec4d20b6ec94e6c8c1caa6eb90f9357bdc18ab2438931466c3f6a0R55
(We talked about creating a cache for this, but that's a bit more advanced. One approach is to do
some prep work by creating a list of all the StopPoints and storing that in a file that can be
used to populate a List when the server starts up. The autocomplete can then filter this list
whenever it is triggered.)

Make the appId, appKey, baseUrl fields of the LineService class (just as you did for the 
JourneyService):
https://github.com/Ameneh-Keshavarz/TFL/commit/f52e86e46b0ec8aa7ecd03cc65c44d8544989bcd#diff-187d3cf7eed834e00314d07b924e1a1e620a52636d1d2f406a3c2eef8e78dc5cR19
(Not really important now, but once you get more endpoints in the class, it will save time and
better performance)

# Classes, Structs and Records
So far we have only talked about Classes, but Structs and Records, in a logical
sense, are very similar. In terms of how they behave in their use of memory they are very different.

Composite types in C# are divided into two catergories:
- **Reference Types**: Variables of a Reference Type are **handles** (i.e. pointers or addresses) to the object that is stored on the Heap. Variables declared in a function or scope are stored on the stack. Function arguments of reference types are passed by reference, meaning that a copy of the handle (8 bytes) is passed instead of the whole object. If the code in the function makes changes to the object, it is seen by the other holders of the handle (the caller).

- **Value Types**: Variables of a Value Type are complete object instances of that Type (i.e. memory allocated for all of the properties and fields of that Type). Variables declared in a function or scope will store the complete object instance on the stack. Remember that stack space is much more limited than heap space, but it does have the advantage that it is much more efficiently cleaned up when no longer required (at the end of each scope or function call). Function arguments of Value Types are passed by value, meaning that a copy of the of the whole object is passed to the function and more stack memory is allocated to store it. If the code in the function makes changes to the object, it is not seen in any other scope. (N.B Value Types **can** be passed by value in a function if the argument is declared using *ref*, *out* or *in*))

**classes**:
- are **Reference Types**
- Can inherit other classes and implement interfaces
- == equality is based on reference (comparing the object address) unless an override function is implemented
  
**structs**:
- are **Value Types**
- Cannot inherit but can implement interfaces
- == equality is based on value (each field is compared)
  
**records**:
- are **Reference Types**
- Can inherit other records and implement interfaces
- == equality is automatically overridden to be based on value.

Conventionally, records are meant to be immutable. If used in this way, they have an advantage over structs since passing them by reference is more efficient, and the guarantee of immutability avoids the bugs that can be introduced by accidental modifications. In modern C# it a good idea to use records in place of structs when the Value Object pattern is implemented and the Model classes in the TFL code is an example.

See  [StructsAndRecords demo](../StructsAndRecords)

# async and await
Since many of the functions in an ASP.NET project use cooperative multitasking (async/await), we talked about this in more depth. cooperative multitasking is a way to allow other parts of the program to execute while one part is waiting for an external event.

async/await are very similar to the same concept  in Javascript and Python. There are slight differences but the effect is the same.

Cooperative multitasking is different from  multithreading. A thread is a flow of execution through your code - think of a needle playing a vinyl record, or a runner running along a race course. Multithreading means having more than one flow of execution (more than one needle on a record, or  more than one runner in a race), so work can be done in parallel at the same time. But a thread is an operating system resource, and something that can be exhausted. If a flow of execution is blocked because it is waiting for an api response, a file read, user input, etc, it cannot do anything else but the thread remains unavailable for others.

async/await cooperative multitasking achieves the same result without using up more threads. When one task is await-ing an async function, other tasks are allowed to run on the same thread. The thread can be kept 100% busy.

Using await inside a function creates a "state machine" which splits the code into steps (separated by the "awaits"). At each await, the **Task Scheduler** uses the Task object (which is returned by the called function) to determine whether the called function has completed (returned) and the caller is ready to resume. 

Marking a function with async enforces that it returns either Task, Task<> or void. This is enforced by the compiler. 

If the function returns void then it can still be called but it cannot be await-ed (because it doesn't return Task).  This means that the caller and the called function continue indepedently. This is a use case commonly called "fire and forget".

See [Async vs Multithread demo](../Async/)

# Delegates, Func<>, Action<>, Task<>
We explored our (including my lack of) understanding around these concepts. This is a summary of what we learned.

As explained above, **Task and Task<>** are returned by an async function if it is intended to be awaited. 

A **delegate** is a user-defined type for referencing a function.
```
delegate <return-type> MyDelegate(arg-types);
MyDelegate func = (args) => ret;
```

**Func and Action** are .NET defined (generic) delegates in the System namespace, defined as follows:
```
 public delegate TResult Func<out TResult>();               // returns a value
 public delegate TResult Func<in T,.., out TResult>(T arg); // accepts argument(s) and returns value
 public delegate void Action();                             // does not return value
 public delegate void Action<in T,...>(T obj)               // accepts argument(s) and does not return value
```

So when you use delegate to define a user-defined type such as MyDelegate, you are defining a new type specific to your program (i.e domain specific). So even though you can have different delegates that accept the same function signature, they are different types. We can think of Func and Action as belonging to the domain of .NET library code, but when you create your own delegates they are specific to your domain.

(It turns out that it **is** possible to convert between delegates that share the same function signature, so it isn't as strict as not being able to convert between classes that look exactly the same, nonetheless it's useful to be able to define domain specific types for clarity purposes, and to support modularity and simplify future refactoring.)

(N.B. Since Javascript variables don't have a type, there is no equivalent to delegate. In Javascript,
the same code would be `const func = (arg-types) => ret)`, so it would be possible to assign anything
to it, not even a callable function)

