using Families;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class PersonExtensionsTests
    {
        // TODO this is cut and paste from PersonTests, refactor to avoid duplication

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
        public PersonExtensionsTests()
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
            Assert.Equal(homer, bart.Father());
            Assert.Equal(marge, bart.Mother());
            Assert.Equal(homer, lisa.Father());
            Assert.Equal(marge, lisa.Mother());
            Assert.Equal(homer, maggie.Father());
            Assert.Equal(marge, maggie.Mother());
            // Assert that Homer has Abe and Mona as parents
            Assert.Equal(abe, homer.Father());
            Assert.Equal(mona, homer.Mother());
        }

        [Fact]
        public void TestLisaAndBartSiblings()
        {
            // Assert that Lisa and Bart are siblings
            Assert.Contains(lisa, bart.Sisters());
            Assert.Contains(bart, lisa.Brothers());
            Assert.Equal(2, bart.Sisters().Count());
            Assert.Single(lisa.Brothers());

            Assert.True(RelationshipQuery.IsSibling(bart, lisa));
            Assert.False(RelationshipQuery.IsSibling(bart, mona));
        }

        [Fact]
        public void TestBartsAunts()
        {
            // Assert that Patty and Selma are aunts of Bart
            var expected = new HashSet<IPerson>() { patty, selma };
            Assert.True(expected.SetEquals ( bart.Aunts().ToHashSet()));
        }
        [Fact]
        public void TestLingCousins()
        {
            // Assert that Ling is a cousin of Bart, Lisa, and Maggie
            var expected = new HashSet<IPerson>() { bart, lisa, maggie };
            Assert.True(expected.SetEquals(ling.Cousins().ToHashSet()));
        }

        [Fact]
        public void TestAbbieHalfSister()
        {
            // Assert that Abbie is a half-sister of Homer
            Assert.Contains(abbie, homer.HalfSiblings());
            Assert.Equal(abe, abbie.GetFather());
            Assert.Equal(edwina, abbie.GetMother());
        }
    }
}
