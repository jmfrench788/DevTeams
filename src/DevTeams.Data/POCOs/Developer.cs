using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Developer
    {
        public Developer(){}

        public Developer(string firstName, string lastName, bool hasPluralsight)
        {
            
            FirstName = firstName;
            LastName = lastName;
            HasPluralsight = hasPluralsight;
        }

        public Developer(int devID, string firstName, string lastName, bool hasPluralsight)
        {
            
            FirstName = firstName;
            LastName = lastName;
            HasPluralsight = hasPluralsight;
            DevID = devID;
        }

        public int DevID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasPluralsight{get; set;}

         public List<Developer> noPluralSight { get; set; } = new List<Developer>();

    }
