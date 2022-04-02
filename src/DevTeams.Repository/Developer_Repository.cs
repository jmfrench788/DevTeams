using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Developer_Repository
    {
        private readonly List<Developer> _developerDatabase = new List<Developer>();

        private readonly List<Developer> _noPluralSight = new List<Developer>();

        private int _count;

//ADD DEV --------------------------------------------------------------------------------------
        public bool AddDevToDatabase(Developer developer)
        {
            if (developer != null)
            {
                _count++;
                developer.DevID = _count;
                _developerDatabase.Add(developer);
                return true;
            }
            else
            { 
                return false;
            }
        }

//SHOW ALL DEVS -------------------------------------------------------------------------------------------
        public List<Developer> GetAllDevelopers()
        {
            return _developerDatabase;
        }

//GET DEV BY ID ----------------------------------------------------------------------------------
        public Developer GetDeveloperByID(int id)
        {
            foreach(var developer in _developerDatabase)
            {
                if(developer.DevID == id)
                {
                    return developer;
                }
            }
            return null;
        }


// list of developers without Pluralsight --------------------------------------------------------


         
    public bool RemoveDevFromDatabase(int id)
    {
        var developer = GetDeveloperByID(id);
        if(developer != null)
        {
            _developerDatabase.Remove(developer);
            return true;
        }
        else{
            return false;
        }
    }
    }

