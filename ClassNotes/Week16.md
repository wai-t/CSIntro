## 18 June 2025
### Checkin
We reminded ourselves of the goals we are trying to achieve. Which is to learn and to train. And we allowed ourselves to be unrestricted in deciding whether we should continue the same path or to change to a different path or to follow multiple paths at the same time. It's also ok if we start a project but don't actually complete it. The goal is always to learn something from it. If it makes it easier to spend time learning by choosing a more interesting path, let's do it.
[Pep Talk](./pep_talk.pptx)

I found an potential good book for learning C#:
- Head First C#, 5th Edition, by Andrew Stellman, Jennifer Greene

I have this (5h edition) on my O'Reilly subscription, but I'm not sure which edition Amazon has. I think it might be this:
https://www.amazon.co.uk/Head-First-Learners-Real-World-Programming/dp/1098141784

Here's a review of it: https://www.linkedin.com/posts/markjamesprice_my-review-of-head-first-c-5th-edition-activity-7283813908904128512-v_eU/

This book will take us away from stereotypical "fullstack", and expose us to Unity, and even MAUI (for mobile phone apps). You'll need to check that your machine has enough power to support Unity https://docs.unity3d.com/Manual/system-requirements.html. I think 8-16 GB memory will be fine, and the installation might take 2-300MB.

Please have a think about the direction you want to take. The more fun and compelling we can make this, the easier it will be to get those lines of code written.

### Build systems
[Building](./build_systems.pptx)
We talked about what we mean by compile and build. (and link in the C/C++ world). We talked about Java and C# and the approach to build to a generic platform by compiling to a machine independent bytecode (for Java) and Intermediate Language (for C#). The fundamental step is the compile (javac or csc), and the build system is what brings all the tasks together including the compile, resolving the location of library files, dependency testing of outputs, and sending the outputs to the right place. There are many build systems to choose from but include MSBuild (for Visual Studio), dotnet build (on the command line), Gradle/Ant (Java).

