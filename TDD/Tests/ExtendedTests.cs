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

        private readonly IPerson abbie; // Homer's half-sister
        private readonly IPerson edwina; // Mother of abbie but never married to Abe

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
            abbie = PersonFactory.Create("Abbie", Gender.Female); // Homer's half-sister
            edwina = PersonFactory.Create("Edwina", Gender.Female); // Mother of abbie but never married to Abe



            // Homer and his parents
            homer.SetFather(abe);
            homer.SetMother(mona);

            // Homer + Marge's kids
            bart.SetFather(homer);
            bart.SetMother(marge);

            lisa.SetFather(homer);
            lisa.SetMother(marge);

            maggie.SetFather(homer);
            maggie.SetMother(marge);

            // Marge, Patty, Selma and their parents
            marge.SetMother(jacqueline);
            marge.SetFather(clancy);

            patty.SetMother(jacqueline);
            patty.SetFather(clancy);

            selma.SetMother(jacqueline);
            selma.SetFather(clancy);

            // Selma's adopted daughter
            ling.SetMother(selma);

            abbie.SetFather(abe); // Abbie is Abe's daughter
            abbie.SetMother(edwina); // Edwina is Abbie's mother but never brought up Homer
        }

        [Fact]
        public void TestHomerAndMargeFamily()
        {
            // Assert that Homer and Marge are parents of Bart, Lisa, and Maggie
            Assert.Equal(homer, bart.GetFather());
            Assert.Equal(marge, bart.GetMother());
            Assert.Equal(homer, lisa.GetFather());
            Assert.Equal(marge, lisa.GetMother());
            Assert.Equal(homer, maggie.GetFather());
            Assert.Equal(marge, maggie.GetMother());
            // Assert that Homer has Abe and Mona as parents
            Assert.Equal(abe, homer.GetFather());
            Assert.Equal(mona, homer.GetMother());
        }

        [Fact]
        public void TestLisaAndBartSiblings()
        {
            // Assert that Lisa and Bart are siblings
            Assert.Contains(lisa, bart.GetSisters());
            Assert.Contains(bart, lisa.GetBrothers());
            Assert.Equal(2, bart.GetSisters().Count());
            Assert.Single(lisa.GetBrothers());

            Assert.True(RelationshipQuery.IsSibling(bart, lisa));
            Assert.False(RelationshipQuery.IsSibling(bart, mona));
        }

        [Fact]
        public void TestBartsAunts()
        {
            // Assert that Patty and Selma are aunts of Bart
            Assert.True(RelationshipQuery.GetRelationship(bart, patty).Is( RelationshipType.Aunt));
            Assert.True(RelationshipQuery.GetRelationship(bart, selma).Is(RelationshipType.Aunt));
            Assert.False(RelationshipQuery.IsSibling(bart, patty));
        }
        [Fact]
        public void TestLingCousins()
        {
            // Assert that Ling is a cousin of Bart, Lisa, and Maggie
            Assert.True(RelationshipQuery.GetRelationship(ling, bart).Is(RelationshipType.Cousin));
            Assert.True(RelationshipQuery.GetRelationship(ling, lisa).Is(RelationshipType.Cousin));
            Assert.True(RelationshipQuery.GetRelationship(ling, maggie).Is(RelationshipType.Cousin));
            Assert.False(RelationshipQuery.IsSibling(ling, homer));
        }

        [Fact]
        public void TestAbbieHalfSister()
        {
            // Assert that Abbie is a half-sister of Homer
            Assert.True(RelationshipQuery.GetRelationship(homer, abbie).Is(RelationshipType.Sister, RelationshipQualifier.Half));
            Assert.False(RelationshipQuery.IsSibling(abbie, homer)); // They are half-siblings
            Assert.Equal(abe, abbie.GetFather());
            Assert.Equal(edwina, abbie.GetMother());
        }
    }
}
