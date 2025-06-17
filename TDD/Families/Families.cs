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
        void setFather(IPerson father);
        void setMother(IPerson mother);
        void addBrother(IPerson brother);
        void addSister(IPerson sister);
        void addSon(IPerson son);
        void addDaughter(IPerson daughter);
        IPerson? getFather();
        IPerson? getMother();
        IEnumerable<IPerson> getBrothers();
        IEnumerable<IPerson> getSisters();
        IEnumerable<IPerson> getSons();
        IEnumerable<IPerson> getDaughters();
        IEnumerable<IPerson> getChildren();
    }
    public class Person : IPerson
    {
        readonly string _id = Guid.NewGuid().ToString();
        public string Id => _id;

        public Person(string name, Gender gender)
        {

        }

        public string Name { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public void addBrother(IPerson brother)
        {
            throw new NotImplementedException();
        }

        public void addDaughter(IPerson daughter)
        {
            throw new NotImplementedException();
        }

        public void addSister(IPerson sister)
        {
            throw new NotImplementedException();
        }

        public void addSon(IPerson son)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> getBrothers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> getChildren()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> getDaughters()
        {
            throw new NotImplementedException();
        }

        public IPerson? getFather()
        {
            throw new NotImplementedException();
        }

        public IPerson? getMother()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> getSisters()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> getSons()
        {
            throw new NotImplementedException();
        }

        public void setFather(IPerson father)
        {
            throw new NotImplementedException();
        }

        public void setMother(IPerson mother)
        {
            throw new NotImplementedException();
        }
    }
}
