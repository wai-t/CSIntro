## 11 March 2025
# Requirements Analysis
We talked out requirements and the importance of having a clear idea of what it is you are trying to program. (*clear doesn't mean complete or final, and can be just the first working iteration of something ) Learning to program without appreciating the importance of understanding the requirements, is like learning about a hammer before you know what a nail is. In business, it's the difference between developers who are key to the project and other programmers.

It is a combination of understanding the business requirement and problem analysis (which in practice means evaluating a range of potential solutions, not just one), communicating both, and evolving both over time.

We looked at the WordleSolver project. The requirement for now is that our program should iteratively make a guess of the target word, receive the feedback about the correctness of the letters and positions, and improve the guess. 

The first attempt at developing a solution is checked in to [WordleCompetition](../WordleCompetition).
We can almost certainly improve on this by leveraging our knowledge of probability, but the initial aim should just be to make something that works.

We can extend the requirements in the future, if, for example, we come across Wordle in other languages, or for more than 5 letters. We might find innovations that fit the same pattern, like guessing phrases or proverbs.

Given the last two paragraphs, we should aim to produce a program which can implement a choice of solution strategies, and be flexible enough to support a range of games in this same pattern. Think of what interfaces we can already design without knowing how they should be implemented.

# Unit Testing
We added some unit testing to the Wordle program.
- For .Net Core projects we should use the xUnit package
- For .Net Framework projects we should use the NUnit package
- Other unit test packages are available.

If the road to success requires travelling through a series of failures, then the idea of writing Unit Tests is to find those failures as soon as you make them. There should be more lines of code in the Unit Tests than in the program. This will feel like a lot of work to do up front, but the saving in time applies for even very small projects. 
- Bugs which are not detected until months or years after they are written take time to find. 
- During those months or years, other bugs are added. The production system operates under a constant cloud of risk.
- Unit Tests are documentation and provide examples of how your software is meant to be used.
- Unit Tests mean that when someone checks out your repo, they can run them to check the build and the correctness of their development environment.
- Unit Tests failures can be activated in parts of the code you didn't even know existed, and would never have realised needed testing after a change.
- Unit Tests are run automatically in Continuous Integration environments. It doesn't need any effort.

# Dependency Injection
We started to talk about Dependency Injection (DI) as a **design pattern**. This is heavily used in ASP.NET and allows us to achieve **Separation of Concerns**:
- Each Service, Controller, etc, (components) in our project only needs to be concerned with the types that is needs to do its job. It doesn't need to worry about how to set up instances of those types, or how those types are implemented. For example, a Service can work with an IDbConnection without knowing whether it is SQLServer or Postgres or MySql, and it doesn't need to know it's connection strings or how to log on to the database. All it needs is the IDbConnection through which it can send standard SQL.
- The startup program is concerned with registering both the components needed by the app and the concrete types needed by the rest of the system. Here is where it will decide what kind of database server to use. Importantly, these decisions can be made based on whether the runtime environment is Development, QA or Production. Other components don't need to be concerned with this. Conversely, the startup program doesn't need to be concerned about how the instances of the dependent types are used by the components, it only needs to be concerned about creating them
- The ASP.NET framework is the glue to all of this by registering all the types created by the startup program, and ensuring that the correct instances of the types are passed into each component when it is instantiated. The framework doesn't need to be concerned with the particular resources that the startup program is setting up or the business problem that the components are addressing. The most common injection method is **Constructor Injection** where ASP.NET uses the type of the contructor arguments to determine which instance is passed to the constructor.

So DI involves components [DI](DI.png), a configuration (the startup), and a framework (ASP.NET). There are other DI frameworks such as Spring in which the configuration is a definition file rather than a program, so DI is just a design pattern that separates responsibly into these three roles. Because an appserver or webserver is a vary common type of application, it means we don't have to re-invent the wheel by implementing a solution that's already been solved. And because of the separation of concerns, tech companies can create comprehensive DI frameworks that support many use cases. ASP.NET supports DI and many other recurring requirements such as Http/Https handling, Authentication, Authorisation, Routing, Lifetime (Scope) management, so we can focus on business requirements.

Even without a third party DI framework, designing components to work in a DI pattern is a good practice, by separating the concerns of production and consumption of resources, and supports testability by allowing the injection of test data sources, mock components, mock clients dependent on runtime environments.