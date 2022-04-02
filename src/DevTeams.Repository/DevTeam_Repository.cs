using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class DevTeam_Repository
    {
        private readonly List<Developer> _teamMembers = new List<Developer>();

        private readonly List<DevTeam> _teams = new List<DevTeam>();

        private int _count;

      public bool AddTeamToDatabase(DevTeam devTeam)
        {
            if(devTeam != null)
            {
                _count++;
                devTeam.TeamID=_count;
                _teams.Add(devTeam);
                return true;
            }
            else
            {
                return false;
            }
        }

          public DevTeam GetTeamByID(int id)
        {
            foreach(var devTeam in _teams)
            {
                if(devTeam.TeamID == id)
                {
                    return devTeam;
                }
            }
            return null;
        }
       

        public bool RemoveTeamFromDatabase(int id)
        {
            var devteam = GetTeamByID(id);
            if (devteam != null)
            {
                _teams.Remove(devteam);
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool AddDevToTeam(Developer developer)
        {
       
            if (developer != null)
            {
            
                _teamMembers.Add(developer);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<DevTeam> GetAllTeams()
        {
            return _teams;
        }

        public bool UpdateTeamData(int teamID, DevTeam newTeamData)
    {
        
        DevTeam oldTeamData = GetTeamByID(teamID);

       
        if (oldTeamData != null) 
        {
            oldTeamData.TeamName = newTeamData.TeamName;
            oldTeamData.Members = newTeamData.Members;
            return true;
        }
        else
        {
            return false;
        }

    }
    }

    





//remove developer from team

