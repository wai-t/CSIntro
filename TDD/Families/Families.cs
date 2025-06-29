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
        public Gender _gender;
        private IPerson? _father;
        private IPerson? _mother;

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
            if (!_brothers.Any(b => b.Id == brother.Id))
                _brothers.Add(brother);

            if (this._gender == Gender.Male)
            {
                if (!brother.getBrothers().Any(b => b.Id == this.Id))
                {
                    brother.addBrother(this);
                }
            }
            else
            {
                if (!brother.getSisters().Any(s => s.Id == this.Id))
                {
                    brother.addSister(this);
                }
            }
        }

        public void addDaughter(IPerson daughter)
        {
            if (!_daughters.Any(d => d.Id == daughter.Id))
                _daughters.Add(daughter);

            if (this._gender == Gender.Male)
            {
                daughter.setFather(this);
            }
            else
            {
                daughter.setMother(this);
            }

            foreach (var son in _sons)
            {
                daughter.addBrother(son);
                son.addSister(daughter);
            }

            foreach (var sister in _daughters)
            {
                if (sister.Id != daughter.Id)
                {
                    daughter.addSister(sister);
                    sister.addSister(daughter);
                }
            }
        }

        public void addSister(IPerson sister)
        {
            if (!_sisters.Any(s => s.Id == sister.Id))
                _sisters.Add(sister);

            if (this._gender == Gender.Male)
            {
                if (!sister.getBrothers().Any(b => b.Id == this.Id))
                {
                    sister.addBrother(this);
                }
            }
            else
            {
                if (!sister.getSisters().Any(s => s.Id == this.Id))
                {
                    sister.addSister(this);
                }
            }
        }

        public void addSon(IPerson son)
        {
            if (!_sons.Any(s => s.Id == son.Id))
                _sons.Add(son);

            if (this._gender == Gender.Male)
            {
                son.setFather(this);
            }
            else
            {
                son.setMother(this);
            }

            foreach (var bro in _sons)
            {
                if (bro.Id != son.Id)
                    son.addBrother(bro);
            }

            foreach (var sister in _daughters)
            {
                son.addSister(sister);
            }
        }

        public IEnumerable<IPerson> getBrothers()
        {
            return _brothers;
        }

        public IEnumerable<IPerson> getChildren()
        {
            return _sons.Concat(_daughters);
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
            _father = father;

            if (this._gender == Gender.Male)
            {
                if (!father.getSons().Any(s => s.Id == this.Id))
                    father.addSon(this);
            }
            else
            {
                if (!father.getDaughters().Any(d => d.Id == this.Id))
                    father.addDaughter(this);
            }
        }

        public void setMother(IPerson mother)
        {
            _mother = mother;

            if (this._gender == Gender.Male)
            {
                if (!mother.getSons().Any(s => s.Id == this.Id))
                    mother.addSon(this);
            }
            else
            {
                if (!mother.getDaughters().Any(d => d.Id == this.Id))
                    mother.addDaughter(this);
            }
        }
    }
}
