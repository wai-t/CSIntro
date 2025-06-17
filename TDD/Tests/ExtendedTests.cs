using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    using Families;

    public class ExtendedTests
    {
        // Fields representing members of the extended family
        private readonly IPerson homer;
        private readonly IPerson marge;
        private readonly IPerson bart;
        private readonly IPerson lisa;
        private readonly IPerson maggie;
        private readonly IPerson abe;
        private readonly IPerson mona;
        private readonly IPerson patty;
        private readonly IPerson selma;
        private readonly IPerson ling;
        private readonly IPerson jacqueline;
        private readonly IPerson clancy;

        public ExtendedTests()
        {
            // Initialize family members
            homer = PersonFactory.Create("Homer", Gender.Male);
            marge = PersonFactory.Create("Marge", Gender.Female);
            bart = PersonFactory.Create("Bart", Gender.Male);
            lisa = PersonFactory.Create("Lisa", Gender.Female);
            maggie = PersonFactory.Create("Maggie", Gender.Female);
            abe = PersonFactory.Create("Abe", Gender.Male);
            mona = PersonFactory.Create("Mona", Gender.Female);
            patty = PersonFactory.Create("Patty", Gender.Female);
            selma = PersonFactory.Create("Selma", Gender.Female);
            ling = PersonFactory.Create("Ling", Gender.Female);
            jacqueline = PersonFactory.Create("Jacqueline", Gender.Female);
            clancy = PersonFactory.Create("Clancy", Gender.Male);

            // Homer and his parents
            homer.setFather(abe);
            homer.setMother(mona);

            // Homer + Marge's kids
            bart.setFather(homer);
            bart.setMother(marge);

            lisa.setFather(homer);
            lisa.setMother(marge);

            maggie.setFather(homer);
            maggie.setMother(marge);

            // Marge, Patty, Selma and their parents
            marge.setMother(jacqueline);
            marge.setFather(clancy);

            patty.setMother(jacqueline);
            patty.setFather(clancy);

            selma.setMother(jacqueline);
            selma.setFather(clancy);

            // Selma's adopted daughter
            ling.setMother(selma);
        }

        [Fact]
        public void TestHomerAndMargeFamily()
        {
            // Assert that Homer and Marge are parents of Bart, Lisa, and Maggie
            Assert.Equal(homer, bart.getFather());
            Assert.Equal(marge, bart.getMother());
            Assert.Equal(homer, lisa.getFather());
            Assert.Equal(marge, lisa.getMother());
            Assert.Equal(homer, maggie.getFather());
            Assert.Equal(marge, maggie.getMother());
            // Assert that Homer has Abe and Mona as parents
            Assert.Equal(abe, homer.getFather());
            Assert.Equal(mona, homer.getMother());
        }

        [Fact]
        public void TestLisaAndBartSiblings()
        {
            // Assert that Lisa and Bart are siblings
            Assert.Contains(lisa, bart.getSisters());
            Assert.Contains(bart, lisa.getBrothers());
            Assert.Equal(2, bart.getSisters().Count());
            Assert.Single(lisa.getBrothers());

            Assert.True(Relationship.IsSibling(bart, lisa));
            Assert.False(Relationship.IsSibling(bart, mona));
        }

        [Fact]
        public void TestBartsAunts()
        {
            // Assert that Patty and Selma are aunts of Bart
            Assert.True(Relationship.GetRelationship(bart, patty) == RelationshipType.Aunt);
            Assert.True(Relationship.GetRelationship(bart, selma) == RelationshipType.Aunt);
            Assert.False(Relationship.IsSibling(bart, patty));
        }
        [Fact]
        public void TestLingCousins()
        {
            // Assert that Ling is a cousin of Bart, Lisa, and Maggie
            Assert.True(Relationship.GetRelationship(ling, bart) == RelationshipType.Cousin);
            Assert.True(Relationship.GetRelationship(ling, lisa) == RelationshipType.Cousin);
            Assert.True(Relationship.GetRelationship(ling, maggie) == RelationshipType.Cousin);
            Assert.False(Relationship.IsSibling(ling, homer));
        }
    }
}
