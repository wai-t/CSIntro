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
        private Gender _gender;
        private IPerson? _father;
        private IPerson? _mother;

        private HashSet<IPerson> _children = new HashSet<IPerson>();
        private HashSet<IPerson> _brothers = new HashSet<IPerson>();
        private HashSet<IPerson> _sisters = new HashSet<IPerson>();
        private HashSet<IPerson> _daughters = new HashSet<IPerson>();
        private HashSet<IPerson> _sons = new HashSet<IPerson>();



        public Person(string name, Gender gender)
        {
            this._name = name;
            this._gender = gender;
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
            if (!this._daughters.Contains(daughter))
            {
                this._daughters.Add(daughter);
            }

            if (!this._children.Contains(daughter))
            {
                this._children.Add(daughter);


            }
        }

        public void addSister(IPerson sister)
        {
            if (!this.getSisters().Contains(sister))
                this._sisters.Add(sister);

            if (!sister.getBrothers().Contains(this))
                sister.addBrother(this);
        }

        public void addSon(IPerson son)
        {
            if (!this._sons.Contains(son))
            {
                this._sons.Add(son);
            }

            if (!this._children.Contains(son))
            {
                this._children.Add(son);
            }
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
            return _daughters;
        }

        public IPerson? getFather()
        {
            return this._father;
        }

        public IPerson? getMother()
        {
            return this._mother;
        }

        public IEnumerable<IPerson> getSisters()
        {
            return _sisters;
        }

        public IEnumerable<IPerson> getSons()
        {
            return _sons;
        }

        public void setFather(IPerson father)
        {
            this._father = father;
            if (this._gender == Gender.Male)
            {
                father.addSon(this);
            }
            else
            {
                father.addDaughter(this);
            }
        }

        public void setMother(IPerson mother)
        {
            this._mother = mother;
            if (this._gender == Gender.Male)
            {
                mother.addSon(this);
            }
            else
            {
                mother.addDaughter(this);
            }
        }
    }
}
