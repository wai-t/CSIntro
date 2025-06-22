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

        private string _name;

        private IPerson _father;

        private HashSet<IPerson> _daughters = new HashSet<IPerson>();

        private HashSet<IPerson> _children = new HashSet<IPerson>();

        private HashSet<IPerson> _brothers = new HashSet<IPerson>();

        private HashSet<IPerson> _sisters = new HashSet<IPerson>();


        public Person(string name, Gender gender)
        {
            this._name = name;

        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public void addBrother(IPerson brother)
        {
            if (!this.getBrothers().Contains(brother))
                this._brothers.Add(brother);

            if (!brother.getSisters().Contains(this))
                brother.addSister(this);
        }

        public void addDaughter(IPerson daughter)
        {
            this._daughters.Add(daughter);
            this._children.Add(daughter);

        }

        public void addSister(IPerson sister)
        {
            if (!this.getSisters().Contains(sister))
                this._sisters.Add(sister);

            if (sister.getBrothers().Contains(this))
                sister.addBrother(this);
        }

        public void addSon(IPerson son)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> getBrothers()
        {
            return _brothers;
        }

        public IEnumerable<IPerson> getChildren()
        {
            return _children;
        }

        public IEnumerable<IPerson> getDaughters()
        {
            throw new NotImplementedException();
        }

        public IPerson? getFather()
        {
            return this._father;
        }

        public IPerson? getMother()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPerson> getSisters()
        {
            return _sisters;
        }

        public IEnumerable<IPerson> getSons()
        {
            throw new NotImplementedException();
        }

        public void setFather(IPerson father)
        {
            this._father = father;
            father.addDaughter(this);
        }

        public void setMother(IPerson mother)
        {
            throw new NotImplementedException();
        }
    }
}
