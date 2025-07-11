using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Families
{
    public enum RelationshipType
    {
        Self,
        Parent,
        Child,
        Brother,
        Sister,
        Grandparent,
        Grandchild,
        Aunt,
        Uncle,
        Niece,
        Nephew,
        Cousin,
        OtherRelationship,
        Unrelated,
        Spouse,
    }

    public enum RelationshipQualifier
    {
        None,
        Half, // applies to siblings if they have one parent in common
        Step  // applies to siblings if they have no parents in common but are related through marriage or adoption
    }

    public record Relationship(RelationshipType Type, RelationshipQualifier Qualifier = RelationshipQualifier.None)
    {
        public bool Is(RelationshipType type) => Type == type;
        public bool Is(RelationshipType type, RelationshipQualifier qualifier) => Type == type && this.Qualifier == qualifier;
    };

    public static class RelationshipQuery
    {
        public static IPerson? GetFather(IPerson person)
        {
            return person.GetFather();
        }
        public static IPerson? GetMother(IPerson person)
        {
            return person.GetMother();
        }
        public static IEnumerable<IPerson> GetUncles(IPerson person)
        {
            var father = person.GetFather();
            var mother = person.GetMother();

            var motherSiblings = mother != null ? mother.GetBrothers() : [];
            var fatherSiblings = father != null ? father.GetBrothers() : [];

            return fatherSiblings.Concat(motherSiblings);

        }

        public static IEnumerable<IPerson> GetAunts(IPerson person)
        {
            var father = person.GetFather();
            var mother = person.GetMother();

            var motherSiblings = mother != null ? mother.GetSisters() : [];
            var fatherSiblings = father != null ? father.GetSisters() : [];

            return fatherSiblings.Concat(motherSiblings);

        }
        public static IEnumerable<IPerson> GetAuntsAndUncles(IPerson person)
        {
            return GetAunts(person).Concat(GetUncles(person));

        }
        public static IEnumerable<IPerson> GetSiblings(IPerson person)
        {
            var father = person.GetFather();
            var mother = person.GetMother();

            var siblings = new HashSet<IPerson>();

            if (father != null)
            {
                foreach (var child in father.GetChildren())
                {
                    if (child != person) siblings.Add(child);
                }
            }

            if (mother != null)
            {
                foreach (var child in mother.GetChildren())
                {
                    if (child != person) siblings.Add(child);
                }
            }

            return siblings;
        }
        public static Relationship GetRelationship(IPerson person, IPerson relative)
        {
            if (person.Equals(relative))
            {
                return new Relationship(RelationshipType.Self);
            }
            else if (GetAunts(person).Contains(relative))
            {
                return new Relationship(RelationshipType.Aunt);
            }
            else if (GetUncles(person).Contains(relative))
            {
                return new Relationship(RelationshipType.Uncle);
            }
            else if (IsSiblingMotherSide(person, relative))
            {
                if (IsSiblingFatherSide(person, relative))
                {
                    return relative is Female ? new Relationship(RelationshipType.Sister) : new Relationship(RelationshipType.Brother);
                }
                else
                {
                    return relative is Female ? new Relationship(RelationshipType.Sister, RelationshipQualifier.Half) : new Relationship(RelationshipType.Brother, RelationshipQualifier.Half);

                }
            }
            else if (IsSiblingFatherSide(person, relative))
            {
                return relative is Female ? new Relationship(RelationshipType.Sister, RelationshipQualifier.Half) : new Relationship(RelationshipType.Brother, RelationshipQualifier.Half);
            }
            else if (IsCousins(person, relative))
            {
                return new Relationship(RelationshipType.Cousin);
            }
            else
            {
                return new Relationship(RelationshipType.Unrelated);
            }

        }

        public static bool IsCousins(IPerson person1, IPerson person2)
        {
            var auntAndUncles = GetAuntsAndUncles(person1);
            return auntAndUncles.Any(p => person2.GetFather() == p || person2.GetMother() == p);

        }
        public static bool IsSibling(IPerson person1, IPerson person2)
        {

            if (person1 == person2) return false;

            bool sameFather = IsSiblingFatherSide(person1, person2);
            bool sameMother = IsSiblingMotherSide(person1, person2);

            return sameFather && sameMother;
        }

        private static bool IsSiblingMotherSide(IPerson person1, IPerson person2)
        {
            if (person1 == person2) return false;
            return person1.GetMother() != null && person1.GetMother() == person2.GetMother();
        }

        public static bool IsSiblingFatherSide(IPerson person1, IPerson person2)
        {
            if (person1 == person2) return false;

            bool sameFather = person1.GetFather() != null && person1.GetFather() == person2.GetFather();

            return sameFather;
        }
        public static bool IsParent(IPerson person, IPerson child)
        {
            return child.GetFather() == person || child.GetMother() == person;
        }
    }
}
