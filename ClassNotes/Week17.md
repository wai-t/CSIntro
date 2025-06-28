## 25 June 2025
### Refocus
We talked about thoughts we had about different strands we can introduce going forward:

### 1. Follow a book

We have access to the 4th Edition of Head First C# (ISBN 1491976705), by Andrew Stellman, Jennifer Greene. And we agreed to make a start on this
and see how it goes.
It includes some labs which use Unity game engine programming. We will keep an open mind of whether to get involved with these until we can assess if the added
complexity might distract from our learning. The opposite view is that getting introduced into a larger system and learning to make our contributions
within that would simulate the most working environments where the projects are big and large amounts of proprietary platform has to be navigated.

### 2. Do more online coding challenges

Do some pair programming

### 3. Continue with projects

TfL is in a good state to take to the next level. We will begin with a migration to swagger ngen generated models which will
save us from the effort of developing boiler plate models and improve productivity.

### 4. Any special topics can also be requested

## TDD
We carried on with the TDD homework. Creating a family tree seemed a simple enough requirement at the start. However one thing we discovered
was that trying to construct the possible relationships involved writing a lot of redundant logic. We had a
problem we understood well but the problem was we were writing code for it several times over. The more code we write the more bugs we have.
The approach we tried today was to see if we can reduce the representation of the family tree down to its fundamental elements. We
postulated that the family tree can be represented by only parent-child relationships. So we got rid of the addBrother and addSister methods
and refactored. We found that this was successful. The Unit Tests still worked after the refactoring, and we removed a lot of redundant code. We
needed to add some more logic to derive the brother/sister/aunt/uncle relationships but by reducing the data fields down to parent-child 
there was less need to constantly check its self-consistency. This reduction process is exactly analogous to the normalisation of
Entity Relationship Modelling for relational databases.

## Homework
We'll all read chapter 1 of the book.
Take TDD further and make the rest of the tests work.