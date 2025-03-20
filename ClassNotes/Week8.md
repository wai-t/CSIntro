## 18 March 2025
# Review of Projects
We spent most of the class time reviewing feedback on the the submitted projects on Github.
The feedback is posted here:

## WordleAI feedback

- The word list file "official_allowed_guesses.txt" - enable "copy to output" 
and change reference to it to a relative path.

- Consider using Microsoft.Extensions.Configuration for configuration. This will allow you to put the 
file reference to "official_allowed_guesses.txt" into appsettings.json, and can remove the
Config class.

- Check on usage of gitignore file - gitignore.txt files don't make Git do anything. The file should
be called .gitignore.

- Let's check the Wordle rules, I think it's this:
  - All the Greens are assigned.
  - Of the remaining letters, Yellow is assigned until there are no more matches.
  - The rest are Black.
  E.g if the target is READY and the guess is ALARM, then bbgbb is the feedback.
if the target is DEEDS and the guess is ADDED, then byyyb is the feedback. (only 2 Ds in the target)

- Needs structuring to support using in a ASP.NET app and a Unit Test Project.
See issue list in https://github.com/Alirezabg/combined_wordlist

## TFL feedback

- Try to remove compiler warnings when they occur. It keeps things manageable in the long run, because some warnings can become important, and they will be swamped by too many unnecessary warnings.

- Secrets should not be in anything that is checked in to Git. In Development, there is dotnet user-secrets. In Github there is another secrets store for each project. Also in Azure.
So the connection strings in appsettings shouldn't show the app keys (if you want them to be kept secret) and
should use a placeholder for the app key, and the you can use string.Format to build the final connection string

- Documenting the TFL objects - let's look at PlantUML.com (see below, there are also  VS and VS Code extensions that support putting these diagrams in markdown)

- At some point, we need to think about restructuring. We should probably put the Models and Services into a new library,
which contains stuff relevant to TFL. This way we can make it easier to add our Unit Test projects. 
(So that's 2 more projects at least)

- It might not be necessary to have both a I<...>Service and a <...>Service at this stage. I think there are versions
of the AddService<>() method that will just accept the class. Reasoning: This may seem to break the SOLID principles,
but these endpoints are specific to TFL, not our code, so we don't want our interfaces to be tied 
into their design. Theoretically, you could imagine TFL in the future outsourcing this data to another
company, and the likelihood is that the 

- Because the StopPoints query can return multiple entries we might need to add an extra user step here, also check if the Stoppint/Query end point can filter on Tube stops only. This might be a good use case for auto-complete, a simpler first solution is best.
Also consider if a lot of the static data can be downloaded from the api once and stored somewhere, e.g. in a database. Or it could be cached on first call (simpler than adding a database at this stage).

# Design Patterns and UML
We introduced UML class diagrams. UML (Unified Markup Language) was designed in the 1990's to help document object oriented
systems in pictures. Many coders, not all, will find this technique more effective than code or pseudocode. From a UML class
diagram it's possible to write the basic framework of the C# classes and interfaces, including their inheritance relationships,
field declarations and method signatures.

There are several tools available to create UML diagrams using a script. One is [PlantUML](https://plantuml.com/class-diagram). Click on Oneline Server or any of the example diagrams to open an editor. These scripts can then be pasted into markdown documents and the diagrams can be rendered in Visual Studio and Visual Studio Code using extensions.

Design Patterns are a common language within many coding teams, and often asked about in interviews. A pattern is simply a recurring solution style, and a knowledge of patterns provides a source of ideas so that we can avoid re-inventing the wheel. The [Design Patterns pdf](./design_patterns.pdf) is my cheatsheet in interview preparations. Alongside Patters are Principles. These include SOLID principles such as Dependency Inversion, which follows the philosphy of the Dependency Injection technique that ASP.NET uses which we talked about last week. The Service Locator patterns is another example which can be used when there is no container such as ASP.NET to do this for us.

We can only cover these at a very broad level at this stage, but with coming project work, we will envounter these patterns in practice and become comfortable in talking about them,

