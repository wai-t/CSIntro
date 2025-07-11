namespace Tests
{
    using Families;
    public class SimpleTests
    {
        public SimpleTests()
        {
            // This constructor is intentionally left empty.
            // It can be used for any setup required before running tests.
        }
        [Fact]
        public void Test1()
        {
            var alice = PersonFactory.Create("Alice", Gender.Female);
            Assert.NotNull(alice);
            Assert.Equal("Alice", alice.Name);
        }

        [Fact]
        public void TestParentAndChild()
        {
            // Given
            var alice = PersonFactory.Create("Alice", Gender.Female);
            var bob = PersonFactory.Create("Bob", Gender.Male);

            // When
            alice.SetFather(bob);

            // Then
            Assert.Equal(bob, alice.GetFather());
            Assert.Contains(alice, bob.GetChildren());
            Assert.Single(bob.GetChildren());
        }

        [Fact]
        public void TestBrotherAndSister()
        {
            // Given
            var alice = PersonFactory.Create("Alice", Gender.Female);
            var chuck = PersonFactory.Create("Chuck", Gender.Male);
            var dad = PersonFactory.Create("Dad", Gender.Male);

            // When
            alice.SetFather(dad);
            chuck.SetFather(dad);

            // Then
            Assert.Contains(chuck, alice.GetBrothers());
            Assert.Contains(alice, chuck.GetSisters());
            Assert.Single(alice.GetBrothers());
            Assert.Single(chuck.GetSisters());
        }

        [Fact]
        public void TestUncleAndAunt()
        {
            // Given
            var alice = PersonFactory.Create("Alice", Gender.Female);
            var bob = PersonFactory.Create("Bob", Gender.Male);
            var amy = PersonFactory.Create("Amy", Gender.Female);
            var gran = PersonFactory.Create("Gran", Gender.Female);

            // When
            alice.SetFather(bob);
            bob.SetMother(gran);
            amy.SetMother(gran);

            // Then
            Assert.True(RelationshipQuery.GetRelationship(alice, amy).Is(RelationshipType.Aunt));
        }

        [Fact]
        public void TestGender()
        {
            // Given
            var alice = PersonFactory.Create("Alice", Gender.Female);
            var bob = PersonFactory.Create("Bob", Gender.Male);

            Assert.Throws<ArgumentException>(() => alice.SetMother(bob));

            Assert.Throws<ArgumentException>(() => bob.SetFather(alice));

            // Tests no longer needed
            //Assert.Throws<ArgumentException>(() => alice.AddDaughter(bob));

            //Assert.Throws<ArgumentException>(() => bob.AddSon(alice));
        }

        [Fact]
        public void TestIdentity()
        {
            // Given
            var alice1 = PersonFactory.Create("Alice", Gender.Female);
            var alice2 = PersonFactory.Create("Alice", Gender.Female);

            Assert.NotEqual(alice1, alice2);

            Assert.True(RelationshipQuery.GetRelationship(alice1, alice1).Is(RelationshipType.Self));
            Assert.True(RelationshipQuery.GetRelationship(alice1, alice2).Is(RelationshipType.Unrelated));
        }

        [Fact]
        public void TestMarriage()
        {
            // Given
            var paul = PersonFactory.Create("Paul", Gender.Male);
            var john = PersonFactory.Create("Bob", Gender.Male);
            var fred = PersonFactory.Create("Fred", Gender.Male);
            var mary = PersonFactory.Create("Mary", Gender.Female);
            fred.SetFather(paul);
            mary.SetFather(john);

            // When
            // Same sex marriage is legal in this model.
            paul.setSpouse(john);

            // Then
            Assert.True(RelationshipQuery.GetRelationship(paul, john).Is(RelationshipType.Spouse));
            Assert.True(RelationshipQuery.GetRelationship(fred, john).Is(RelationshipType.Parent, RelationshipQualifier.Step));
            Assert.True(RelationshipQuery.GetRelationship(fred, mary).Is(RelationshipType.Sister, RelationshipQualifier.Step));
            Assert.True(RelationshipQuery.GetRelationship(mary, fred).Is(RelationshipType.Brother, RelationshipQualifier.Step));
        }
    }
}