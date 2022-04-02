using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class DevTeam
    {
        public DevTeam (){}
        public DevTeam(string teamName)
        {

            TeamName = teamName;
        }

        public DevTeam(string teamName, List<Developer> members)
        {
            
            TeamName = teamName;
            Members = members;
        }

        public int TeamID { get; set; }

        public string TeamName { get; set;}

        public List<Developer> Members {get; set;} = new List<Developer>();


         
       
    }
