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
            alice.setFather(bob);

            // Then
            Assert.Equal(bob, alice.getFather());
            Assert.Contains(alice, bob.getChildren());
            Assert.Single(bob.getChildren());
        }

        [Fact]
        public void TestBrotherAndSister()
        {
            // Given
            var alice = PersonFactory.Create("Alice", Gender.Female);
            var chuck = PersonFactory.Create("Chuck", Gender.Male);

            // When
            alice.addBrother(chuck);

            // Then
            Assert.Contains(alice, chuck.getBrothers());
            Assert.DoesNotContain(alice, chuck.getSisters());
            Assert.Single(chuck.getBrothers());
            Assert.Empty(chuck.getSisters());
        }

        [Fact]
        public void TestUncleAndAunt()
        {
            // Given
            var alice = PersonFactory.Create("Alice", Gender.Female);
            var bob = PersonFactory.Create("Bob", Gender.Male);
            var amy = PersonFactory.Create("Amy", Gender.Female);

            // When
            alice.setFather(bob);
            bob.addSister(amy);

            // Then
            Assert.Equal(RelationshipType.Aunt, Relationship.GetRelationship(alice, amy));
        }
    }
}