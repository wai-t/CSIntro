
namespace Families
{
    public enum Gender
    {
        Male,
        Female
    }
    public interface IPerson
    {
        string Id { get; }
        string Name { get; set; }
        void SetFather(IPerson father);
        void SetMother(IPerson mother);
        void AddSon(IPerson son);
        void AddDaughter(IPerson daughter);
        IPerson? GetFather();
        IPerson? GetMother();
        IEnumerable<IPerson> GetBrothers();
        IEnumerable<IPerson> GetSisters();
        IEnumerable<IPerson> GetSons();
        IEnumerable<IPerson> GetDaughters();
        IEnumerable<IPerson> GetChildren();
    }
    public abstract class Person : IPerson, IEquatable<Person?>
    {
        // For every method, is it abstract, virtual, or concrete?
        readonly string _id = Guid.NewGuid().ToString();
        public string Id => _id;

        public Person(string name)
        {

        }

        public string Name { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        
        public void AddDaughter(IPerson daughter)
        {
            throw new NotImplementedException();
        }

        public void AddSon(IPerson son)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> GetBrothers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> GetDaughters()
        {
            throw new NotImplementedException();
        }

        public IPerson? GetFather()
        {
            throw new NotImplementedException();
        }

        public IPerson? GetMother()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> GetSisters()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> GetSons()
        {
            throw new NotImplementedException();
        }

        public void SetFather(IPerson father)
        {
            throw new NotImplementedException();
        }

        public void SetMother(IPerson mother)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person? other)
        {
            return other is not null &&
                   _id == other._id;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public static bool operator ==(Person? left, Person? right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person? left, Person? right)
        {
            return !(left == right);
        }
    }

    public class  Male : Person 
    {
        public Male(string name) : base(name)
        {

        }
    }
    public class Female : Person
    {
        public Female(string name) : base(name)
        {

        }
    }
}
