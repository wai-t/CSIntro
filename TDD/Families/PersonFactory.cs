using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Families
{
    public static class PersonFactory
    {
        public static IPerson Create(string name, Gender gender)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }   

            return (gender == Gender.Male) ? new Male(name) : new Female(name);
        }
    }
}
