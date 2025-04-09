## 01 Apr 2025
# Review of Projects
## [Wordle](https://github.com/Alirezabg/combined_wordlist)
Good start to Unit Tests

You might find you need to vary the Mock objects you create so ctor of WordleServiceTests might not be
the best place to create them. You might want to create a new mock object for each test case.
Also you asked for one of the mock functions to be Verifiable but you didn't actually verify
https://github.com/Alirezabg/combined_wordlist/blob/f0189f2546b9a5613cb486f2980a7f7fa8951cc8/CombinedWordlist.Server.Tests/WordleServiceTests.cs#L25

You need quite a few more test cases for the CheckGuess method. Remember this is 
the core of your application. Need more than just the one test case with two words in the list.
You could actually just include the whole word list instead of the FakeService.
https://github.com/Alirezabg/combined_wordlist/blob/f0189f2546b9a5613cb486f2980a7f7fa8951cc8/CombinedWordlist.Server.Tests/WordleGameTests.cs#L23

I wonder if a sorted list might be better for ValidWords. For a HashSet, ElementAt() is $O(N)$ while Contains() is $O(1)$. For a SortedList, ElementAt() is $O(logN)$ while Contains() is $O(log N)$. So even though you call Contains() 6 times for every ElementAt(), the highest order ($O(N)$) is the one that matters when scaling. Not important at these
volumes but should be aware of the issue in general when writing for production.
https://github.com/Alirezabg/combined_wordlist/blob/f0189f2546b9a5613cb486f2980a7f7fa8951cc8/combined_wordlist.Server/WordleGame.cs#L12

CheckGuess() is still returning dual results. You should return a status (maybe use an enum) as well as the hints.
https://github.com/Alirezabg/combined_wordlist/blob/f0189f2546b9a5613cb486f2980a7f7fa8951cc8/combined_wordlist.Server/WordleGame.cs#L18

Some redundant code. Clean up while refactoring. It'll make life a lot easier in the long run!
https://github.com/Alirezabg/combined_wordlist/blob/f0189f2546b9a5613cb486f2980a7f7fa8951cc8/combined_wordlist.Server/Controllers/WordleController.cs#L16C33-L16C42

Nice use of the MemoryCache!
https://github.com/Alirezabg/combined_wordlist/blob/f0189f2546b9a5613cb486f2980a7f7fa8951cc8/combined_wordlist.Server/Services/WordleService.cs#L41

Can we try to make WordleService a singleton? Otherwise it will load the _wordsCache every time. Check its lifetime/scope. Otherwise, we can also load the Word list into
the memoryCache too.
https://github.com/Alirezabg/combined_wordlist/blob/f0189f2546b9a5613cb486f2980a7f7fa8951cc8/combined_wordlist.Server/Services/WordleService.cs#L21

## [TFL feedback](https://github.com/Ameneh-Keshavarz/TFL)
Good start to the unit testing! I wonder if some of the construction wasn't really necessary for the purpose of the test
https://github.com/Ameneh-Keshavarz/TFL/blob/e63295ac0ee3771d9f479d8a9af854e6fd23207e/tfl-stats.Tests/LineServiceTest.cs#L11

You could also try to add some "integration tests" to check out the Tfl API responses.

Unnecessary cast
https://github.com/Ameneh-Keshavarz/TFL/blob/e63295ac0ee3771d9f479d8a9af854e6fd23207e/tfl-stats.Tests/LineServiceTest.cs#L84

Unfortunately, I didn't get round to installing Redis so couldn't actually test.

Lovely use of generics!
https://github.com/Ameneh-Keshavarz/TFL/blob/e63295ac0ee3771d9f479d8a9af854e6fd23207e/tfl-stats.Server/Client/ApiClient.cs#L16

You could probably move all the connection/tokens stuff in the ApiClient class
https://github.com/Ameneh-Keshavarz/TFL/blob/e63295ac0ee3771d9f479d8a9af854e6fd23207e/tfl-stats.Server/Services/JourneyService.cs#L27
https://github.com/Ameneh-Keshavarz/TFL/blob/e63295ac0ee3771d9f479d8a9af854e6fd23207e/tfl-stats.Server/Services/LineService.cs#L23
https://github.com/Ameneh-Keshavarz/TFL/blob/e63295ac0ee3771d9f479d8a9af854e6fd23207e/tfl-stats.Server/Services/StopPointService.cs#L29
And there is also a way to handle the http handler....

You should probably focus only on putting secret in user secrets too, 
the baseUrl isn't really a secret.

# Other Topics #
We covered 
- Caching and comparative speed of access depending on the source of the data 
- ASP.NET singleton, scoped and transient services
- The C# static modifier for classes, methods, fields and properties
- The difference between scope and lifetime for C# types and variables
- The difference between Assemblies and Namespaces (and Nuget packages, which are collections of Assemblies)
These notes are in the [Week11.pptx](Week11.pptx)

I have updated the [Design Patterns](../DesignPatterns) solution with some examples of caching techniques and scope and lifetime.