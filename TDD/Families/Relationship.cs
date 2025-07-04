using System;
using System.Collections.Generic;
using System.Linq;
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
        Unrelated
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
            throw new NotImplementedException("Method not implemented yet.");
        }
        public static IPerson? GetMother(IPerson person)
        {
            throw new NotImplementedException("Method not implemented yet.");
        }
        public static IEnumerable<IPerson> GetSiblings(IPerson person)
        {
            throw new NotImplementedException("Method not implemented yet.");
        }
        public static Relationship GetRelationship(IPerson person, IPerson relative)
        {
            throw new NotImplementedException("Method not implemented yet.");
        }

        public static bool IsSibling(IPerson person1, IPerson person2)
        {
            throw new NotImplementedException("Method not implemented yet.");
        }

        public static bool IsParent(IPerson person, IPerson child)
        {
            throw new NotImplementedException("Method not implemented yet.");
        }
    }
}
