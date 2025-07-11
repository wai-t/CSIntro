## 09-July-2025
### TDD 3.0 Homework

AddSon() and AddDaughter made obselete and replaced by AddChild()
Having two methods isn't adding any value and invites a runtime exception if you use the wrong one.

SetSpouse() added to the IPerson interface - Note that this model allows for same sex marriage.

Begin a migration of RelationShip class code to PersonExtensions, which uses extension methods
because these are probably easier to use with intellisense code completion.