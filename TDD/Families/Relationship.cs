using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Families
{
    public enum RelationshipType
    {
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
    public static class Relationship
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
        public static RelationshipType GetRelationship(IPerson person, IPerson relative)
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
