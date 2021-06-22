using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPoco
{
    public class Developers
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public bool PluralSight { get; set; }

        public Developers()
        {

        }

        public Developers(string firstName, string lastName, int id, bool pluralSight)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
            PluralSight = pluralSight;

        }
    }
}