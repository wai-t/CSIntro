## 04-July-2025
### Review of Chapter 1
Chapter 1 was straightforward to follow. But at this stage:
- if you can't explain it back line by line, you haven't understood all of it.
- try not be content with black boxes that just work, try to get an idea of what's happening under the hood.

I've added a last slide to [Build Systems](build_systems.pptx) to give you an idea of how the XAML is processed.

### Tfl 2.0
Migration of LineClient and Journey seems to be complete. Still to do the StopPoint functionality.

We need to research the stage, Domain Analysis of what data the Tfl provides, make sure we understand it
and make sure it does what we think it does. Then based on that, specify what we want Tfl 2.0 to do.
[Analysis requirements](The%20Tfl%20Project.pptx)

### TDD 2.0
Upgraded the homework to include half-sibling relationships and refactored the solution classes to make
the Person class now abstract, and add new Male and Female classes derived from this. The work here will
be to decide whether methods are virtual, abstract, override or just a single method. 
