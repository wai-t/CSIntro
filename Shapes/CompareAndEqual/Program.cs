namespace CompareAndEqual
{
    public class MyItem(string id) : 
        IComparable<MyItem>, // required here if we want to call Sort() (without the argument) on a collection containing MyItems
        IEquatable<MyItem>   // required here if we want to put MyItems into a HashSet.
    {
        public string Id { get; } = id;

        // only for demonstrating CompareTo, using a subkey as well as the main key.
        // Ignore the fact that we are also initialising with the same id.
        public string SubId { get; } = id;

        // Needed for sorting with .NET collection extension methods
        public int CompareTo(MyItem? other)
        {
            // Example of supporting sorting using more than one field or key

            // First compare the main key, and return immediately if it
            // if the main keys are not tied.
            var ret = this.Id.CompareTo(other?.Id);
            if (ret != 0) return ret;

            // If the main keys are tied, then compare the subkey too.
            return this.SubId.CompareTo(other?.SubId);
        }

        // Needed for HashSets
        public bool Equals(MyItem? other)
        {
            return Id.Equals(other?.Id);
        }

        // Needed for HashSets
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string? ToString()
        {
            return Id;
        }

    }

    // Create your own Custom IComparer if you want the ability to
    // sort your items in a different way from the CompareTo method implemented in
    // your MyItem class.
    public class MyItemComparer : IComparer<MyItem>
    {
        public int Compare(MyItem? x, MyItem? y)
        {
            return -(x?.Id.CompareTo(y?.Id) ?? (y==null ? 0 : -1));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MyItem> list = [new("A"), new("B"), new("C"), new("B")];

            //list.Sort();
            list.Sort(new MyItemComparer());

            var x = new MyItem("a");
            var y = new MyItem("b");



            foreach (var item in list)
            {
                Console.WriteLine($"{item}");
            }

            HashSet<MyItem> set = [new("A"), new("B"), new("C"), new("B")];
            //HashSet<string> set = [new("A"), new("B"), new("C"), new("B")];
            foreach (var item in set)
            {
                Console.WriteLine($"{item}");
            }

        }
    }
}
