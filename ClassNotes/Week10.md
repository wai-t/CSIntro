## 01 Apr 2025
# Review of Projects
## [Wordle](https://github.com/Alirezabg/combined_wordlist)
I'm not sure if your guess matching logic is correct yet. This is where you need to be documenting
your algorithm and backing that up with a set of unit tests.
https://github.com/Alirezabg/combined_wordlist/blob/e5759d763e6cec42e605d5164f59a6e0db23664d/combined_wordlist.Server/Controllers/WordleController.cs#L142
https://github.com/Alirezabg/combined_wordlist/blob/e5759d763e6cec42e605d5164f59a6e0db23664d/combined_wordlist.Server/WordleGame.cs#L41

Need to break out a Service from the controller for the LoadWords,GetGame,SaveGame methods
https://github.com/Alirezabg/combined_wordlist/blob/e5759d763e6cec42e605d5164f59a6e0db23664d/combined_wordlist.Server/Controllers/WordleController.cs#L13
https://github.com/Alirezabg/combined_wordlist/blob/e5759d763e6cec42e605d5164f59a6e0db23664d/combined_wordlist.Server/Controllers/WordleController.cs#L24
https://github.com/Alirezabg/combined_wordlist/blob/e5759d763e6cec42e605d5164f59a6e0db23664d/combined_wordlist.Server/Controllers/WordleController.cs#L37
And then inject the Service into the controller

Also SolvePuzzle/MatchesHint, should be in a business class, not in the controller
https://github.com/Alirezabg/combined_wordlist/blob/e5759d763e6cec42e605d5164f59a6e0db23664d/combined_wordlist.Server/Controllers/WordleController.cs#L101
https://github.com/Alirezabg/combined_wordlist/blob/e5759d763e6cec42e605d5164f59a6e0db23664d/combined_wordlist.Server/Controllers/WordleController.cs#L136C18-L136C29

Storing GameData in a session string: This is probably ok for now. It's not very scalable when the object
is large. De/Serializing the object to/from a string is not very efficient, so it would be better not to
do it if you don't need it.
https://github.com/Alirezabg/combined_wordlist/blob/e5759d763e6cec42e605d5164f59a6e0db23664d/combined_wordlist.Server/Controllers/WordleController.cs#L26

CheckGuess() Don't encode "special meanings" into string returns. It just makes the calling code more complex,
and harder to understand. Return a structured value, e.g. (<5 letter hint>, [correct|incorrect|erro]).
https://github.com/Alirezabg/combined_wordlist/blob/e5759d763e6cec42e605d5164f59a6e0db23664d/combined_wordlist.Server/WordleGame.cs#L18
I'm not actually sure if you are checking the "Correct! You Win!" condition.

## [TFL feedback](https://github.com/Ameneh-Keshavarz/TFL)
Unit Test!

I think the autocomplete needs to split the data list into two different variables
https://github.com/Ameneh-Keshavarz/TFL/blob/8652424788ebfd25f49f542fb4b76e0fcf267829/tfl-stats.Client/src/Journey.jsx#L56
https://github.com/Ameneh-Keshavarz/TFL/blob/8652424788ebfd25f49f542fb4b76e0fcf267829/tfl-stats.Client/src/Journey.jsx#L71

Using user secrets now, so put a instruction on how to set it up in readme.md

I added "mode=tube" to the query string to remove lots of irrelevant suggestions

# Dependencies, SOLID principles
We spent the rest of the session with a presentation about [Dependencies and SOLID Principles](./Week10.pptx) and talked about
how design for software is about **Designing for Change** and not about designing something that resists change. I didn't actually show it during the Session but the code examples in the presentation are also in this [project](../DesignPatterns/DesignPatterns.sln)