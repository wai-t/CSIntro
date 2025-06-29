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
            return person.getFather();
        }
        public static IPerson? GetMother(IPerson person)
        {
            return person.getMother();
        }
        public static IEnumerable<IPerson> GetSiblings(IPerson person)
        {
            return person.getBrothers().Concat(person.getSisters());
        }
        public static RelationshipType GetRelationship(IPerson person, IPerson relative)
        {
            // Unrelated 
            if (person == null || relative == null)
                return RelationshipType.Unrelated;

            // OtherRelationship
            if (person.Id == relative.Id)
                return RelationshipType.OtherRelationship;

            // Parent
            if (IsParent(person, relative))
                return RelationshipType.Parent;

            // Child
            if (IsParent(relative, person))
                return RelationshipType.Child;

            // Brother or Sister
            if (IsSibling(person, relative))
            {
                var personImpl = person as Person;
                if (personImpl != null && personImpl._gender == Gender.Male)
                    return RelationshipType.Brother;
                else
                    return RelationshipType.Sister;
            }

            // Grandparent, Grandchild
            var father = person.getFather();
            var mother = person.getMother();

            if (father != null && (IsParent(father, relative)))
                return RelationshipType.Grandparent;

            if (mother != null && (IsParent(mother, relative)))
                return RelationshipType.Grandparent;

            if (IsParent(relative, father) || IsParent(relative, mother))
                return RelationshipType.Grandchild;

            // Uncle or Aunt
            if (father != null)
            {
                var siblingsOfFather = GetSiblings(father);
                if (siblingsOfFather.Contains(relative))
                {
                    var personImpl = relative as Person;
                    if (personImpl != null && personImpl._gender == Gender.Male)
                        return RelationshipType.Uncle;
                    else
                        return RelationshipType.Aunt;
                }
            }

            if (mother != null)
            {
                var siblingsOfMother = GetSiblings(mother);
                if (siblingsOfMother.Contains(relative))
                {
                    var personImpl = relative as Person;
                    if (personImpl != null && personImpl._gender == Gender.Male)
                        return RelationshipType.Uncle;
                    else
                        return RelationshipType.Aunt;
                }
            }

            // Nephew or Niece
            var fatherOfRelative = relative.getFather();
            var motherOfRelative = relative.getMother();
            var siblings = GetSiblings(person);

            if (fatherOfRelative != null && motherOfRelative != null)
            {
                if (siblings.Any(s => s.Id == fatherOfRelative.Id) || siblings.Any(s => s.Id == motherOfRelative.Id))
                {
                    var personImpl = relative as Person;
                    if (personImpl != null && personImpl._gender == Gender.Male)
                        return RelationshipType.Nephew;
                    else
                        return RelationshipType.Niece;

                }
            }

            // Cousin
            var fatherOfPerson = GetFather(person);
            var fatherOfPersonSiblings = false;
            var motherOfPersonSiblings = false;
            if (fatherOfPerson != null)
            {
                fatherOfPersonSiblings = GetSiblings(fatherOfPerson)
                                      .Any(s => s.Id == fatherOfRelative.Id);
            }
            var motherOfPerson = GetMother(person);
            if (motherOfPerson != null)
            {
                motherOfPersonSiblings = GetSiblings(motherOfPerson)
                                      .Any(s => s.Id == motherOfRelative.Id);
            }

            if (fatherOfPersonSiblings || motherOfPersonSiblings)
                return RelationshipType.Cousin;


            return RelationshipType.OtherRelationship;
        }
        public static bool IsSibling(IPerson person1, IPerson person2)
        {
            if (person1.getBrothers().Contains(person2) ||
                person1.getSisters().Contains(person2))
                return true;
            return false;
        }
        public static bool IsParent(IPerson person, IPerson child)
        {
            if (person.getSons().Contains(child) ||
                person.getDaughters().Contains(child))
                return true;
            return false;
        }
    }
}
