
using System.Security.Cryptography.X509Certificates;

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
        protected string _name;
        private IPerson? _father;
        private IPerson? _mother;
        private readonly List<IPerson> _children = new();


        public Person(string name)
        {
            _name = name;

        }

        public string Name {
            get => _name;
            set => _name = value;
        }

        
        public void AddDaughter(IPerson daughter)
        {
            if(daughter is not Female) throw new ArgumentException("Daughter must be female.");
            if (!_children.Contains(daughter))
            {
                _children.Add(daughter);
            }

        }

        public void AddSon(IPerson son)
        {
            if (son is not Male) throw new ArgumentException("Son must be male.");
            if (!_children.Contains(son))
            {
                _children.Add(son);
            }
        }

        public IEnumerable<IPerson> GetBrothers()
        {
            var parents = new[] { _father, _mother }.Where(p => p != null);
            return parents
                .SelectMany(p => p!.GetChildren())
                .Where(s => s is Male && s != this)
                .Distinct();
        }

        public IEnumerable<IPerson> GetChildren()
        {
            return _children;
        }

        public IEnumerable<IPerson> GetDaughters()
        {
            return _children.Where(c => c is Female);
        }

        public IPerson? GetFather()
        {
            return _father;
        }

        public IPerson? GetMother()
        {
            return _mother;
        }

        public IEnumerable<IPerson> GetSisters()
        {
            var parents = new[] { _father, _mother }.Where(p => p != null);
            return parents
                .SelectMany(p => p!.GetChildren())
                .Where(s => s is Female && s != this)
                .Distinct();
        }

        public IEnumerable<IPerson> GetSons()
        {
            return _children.Where(c => c is Male);
        }

        public virtual void  SetFather(IPerson father)
        {
            _father = father;
        }

        public virtual void SetMother(IPerson mother)
        {
            _mother = mother;
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

        public override void SetFather(IPerson father)
        {
            if (father is not Male) throw new ArgumentException("Father must be male.");
            base.SetFather(father);
            father.AddSon(this);
        }

        public override void SetMother(IPerson mother)
        {
            if (mother is not Female) throw new ArgumentException("Mother must be female.");
            base.SetMother(mother);
            mother.AddSon(this);
        }
    }
    public class Female : Person
    {
        public Female(string name) : base(name)
        {

        }

        public override void SetFather(IPerson father)
        {
            if (father is not Male) throw new ArgumentException("Father must be male.");
            base.SetFather(father);
            father.AddDaughter(this);
        }

        public override void SetMother(IPerson mother)
        {
            if (mother is not Female) throw new ArgumentException("Mother must be female.");
            base.SetMother(mother);
            mother.AddDaughter(this);
        }
    }
}
