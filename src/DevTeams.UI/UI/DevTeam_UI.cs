using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class DevTeam_UI
    {
        private readonly Developer_Repository _dRepo = new Developer_Repository();
        private readonly DevTeam_Repository _tRepo = new DevTeam_Repository();

        private readonly NoPluralSight_Repository _pRepo = new NoPluralSight_Repository();


        public void Run()
        {
              //seed Data
            SeedData();
            //RunAppllication
            RunApplication();
        }

    private void RunApplication()
    {
        bool isRunning = true;
        while(isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("------Komodo Insurance DevTeams------");
            System.Console.WriteLine("Please make a selection: \n"+
            
            "---Developers--- \n" +
            "1. View All Developers \n" +
            "2. Get Developer by ID \n" +
            "3. Add a Developer \n" +
            "4. Remove a Developer \n" +
            "5. View Developers without Pluralsight Access \n" +
            "---Teams--- \n" +
            "6. View All Teams \n" +
            "7. Get Team by ID \n" +
            "8. Update a Team \n" +
            "9. Remove a Team \n" +
            "-------------------------------- \n"+
            "50. Close Application \n" 
            );

            var userInput = Console.ReadLine();
            
            switch(userInput)
            {
                case "1":
                AllDevelopers();
                break;

                case "2":
                GetDevByID();
                break;

                case "3":
                AddDevToDatabase();
                break;

                case "4":
                RemoveDevFromDatabase();
                break;

                case "5":
                GetDevsNoPluralsight();
                break;

                case "6":
                ViewAllTeams();
                break;

                 case "7":
                GetTeamByID();
                break;

                case "8":
                UpdateATeam();
                break;

                case "9":
                RemoveATeam();
                break;

                case "50":
                isRunning = CloseApplication();
                break;

                default:
                System.Console.WriteLine("Invalid Selection");
                PressAnyKeyToContinue();
                break;
            }


        }
    }

 

    private void GetTeamByID()
    {
        Console.Clear();
        System.Console.WriteLine("---Team Details---");
        var teams = _tRepo.GetAllTeams();
        foreach (DevTeam devTeam in teams)
        {
            DisplayTeamListing(devTeam);
        }


        try
        {
            System.Console.WriteLine("Please select a team by its ID.");
            var userInputSelectedTeam = int.Parse(Console.ReadLine());
            var selectedTeam = _tRepo.GetTeamByID(userInputSelectedTeam);
            if(selectedTeam != null)
            {
                DisplayTeamDetails(selectedTeam);
            }
            else
            {
                System.Console.WriteLine($"Sorry the team with tht ID: {userInputSelectedTeam} doesn't exist.");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, invalid selection.");
        }

        
    }

    private void DisplayTeamListing(DevTeam devTeam)
    {
         System.Console.WriteLine($" ID: {devTeam.TeamID}\n" +
         $" Team Name: {devTeam.TeamName}");
    }

    private void DisplayTeamDetails(DevTeam selectedTeam)
    {
        Console.Clear();
        System.Console.WriteLine($" Team ID: {selectedTeam.TeamID}\n"+
        $"Team Name: {selectedTeam.TeamName}\n");

        System.Console.WriteLine("--Team Members--");
        if (selectedTeam.Members.Count >0)
        {
              foreach(var developer in selectedTeam.Members)
                {
                    DisplayDeveloperInfo(developer);
                }
        }
        else
        {
            System.Console.WriteLine("There are no team members,");
        }
        System.Console.WriteLine("---------------------------\n");

        PressAnyKeyToContinue();
        
    }

    private void GetDevByID() //double Pressany key to continue
    {
        Console.Clear();
        System.Console.WriteLine("=== Developer Detail Menu ===\n");
        System.Console.WriteLine("                            ");
        AllDevelopers();
        System.Console.WriteLine("Please enter a Developer ID: \n");

        var userInputSelectedDev = int.Parse(Console.ReadLine()); 
        var selectedDev = _dRepo.GetDeveloperByID(userInputSelectedDev);
        
        if(selectedDev != null)
        {
            DisplayDeveloperInfo(selectedDev);
        }
        else
        {
            System.Console.WriteLine($"The Developer with the ID: {userInputSelectedDev} doesn't exist.");
        }
        PressAnyKeyToContinue();

    }

    private void DisplayDeveloperInfo(Developer developer)
    {
        System.Console.WriteLine($" ID: {developer.DevID}\n" +
        $" First Name: {developer.FirstName}\n"+
        $" Last Name: {developer.LastName}\n" +
        $" PluralSight Access: {developer.HasPluralsight}\n"+
        "                                     ");
    }

    

    //TODO: RemoveATeam
    private void RemoveATeam()
    {
        Console.Clear();
        ViewAllTeams();
             System.Console.WriteLine("Enter the ID of the team you want to remove.");
        int enteredID = int.Parse(Console.ReadLine());
        bool removalSuccess = _tRepo.RemoveTeamFromDatabase(enteredID);

        if(removalSuccess == true)
        {
            System.Console.WriteLine("Team was deleted.");
        }
        else{
            System.Console.WriteLine("Team failed to be removed.");
        }

        PressAnyKeyToContinue();
    }


    private void UpdateATeam()
    {
        
         Console.Clear();
        var allTeams = _tRepo.GetAllTeams();

        foreach(var team in allTeams)
        {
            DisplayTeamListing(team);
            System.Console.WriteLine("                     ");
        }

        System.Console.WriteLine("Enter a valid team ID.");
        var userInputTeamID = int.Parse(Console.ReadLine());
        var userSelectedTeam = _tRepo.GetTeamByID(userInputTeamID);
        var newTeam = new DevTeam();

        if(userSelectedTeam !=null)
        {
        Console.Clear();
        

        
        var currentTeam = _dRepo.GetAllDevelopers(); 
        
        System.Console.WriteLine("Please enter a team name. ");
        newTeam.TeamName = Console.ReadLine();

        bool hasMembers = false;
        while(!hasMembers)
        {
            System.Console.WriteLine("Do you have a developer you would like to add to the team? y/n");
            var userInputHasMembers = Console.ReadLine();

            if(userInputHasMembers == "Y".ToLower())
            {

                foreach(var developer in currentTeam)
                {
                    System.Console.WriteLine($"ID: {developer.DevID}      Name: {developer.FirstName} {developer.LastName}");
                }
                
                System.Console.WriteLine("Who would you like to add to the team? Enter the ID.");
                var userInputDevSelection = int.Parse(Console.ReadLine());
                var selectedDev = _dRepo.GetDeveloperByID(userInputDevSelection);

                if(selectedDev != null)
                {
                    newTeam.Members.Add(selectedDev);
                    currentTeam.Remove(selectedDev);

                    System.Console.WriteLine($"--Successfully added: {selectedDev.FirstName} {selectedDev.LastName}--");
                }
                else
                {
                    System.Console.WriteLine($"The developer with the ID: {userInputDevSelection} does not exist");
                }
            }
            else
            {
                hasMembers = true;
            }
        }
        }

        var isSuccessful = _tRepo.UpdateTeamData(userSelectedTeam.TeamID, newTeam);
        if(isSuccessful)
        {
            System.Console.WriteLine("--Team update successful!--");
        }
        else
        {
            System.Console.WriteLine("--Update failed--");
        }
        


        PressAnyKeyToContinue();
    }
    

    private void AddDevToTeam()
    {
    
    }

    private void ViewAllTeams()
    {
        Console.Clear();
        System.Console.WriteLine("---Team Details---");
        var teams = _tRepo.GetAllTeams();
        foreach (DevTeam devTeam in teams)
        {
            DisplayTeamListing(devTeam);
        }
        PressAnyKeyToContinue();
    }

    private void DisplayTeams(DevTeam team)
    {
        System.Console.WriteLine($" Team ID: {team.TeamID} Team Name: {team.TeamName} \n");
    }

    private void GetDevsNoPluralsight()
    {
        Console.Clear();
        var developersNoPS = _pRepo.GetAllPSDevelopers;
        System.Console.WriteLine("---Developers Without PluralSight Access---\n");
        
        Console.Clear();

        foreach(Developer developer in developersNoPS)
        {
            System.Console.WriteLine(developer);
        }
        

        PressAnyKeyToContinue();
    }
       

    

    private void RemoveDevFromDatabase()
    {
        AllDevelopers();
        System.Console.WriteLine("Enter the ID of the developer you want to remove.");
        int enteredID = int.Parse(Console.ReadLine());
        bool removalSuccess = _dRepo.RemoveDevFromDatabase(enteredID);

        if(removalSuccess == true)
        {
            System.Console.WriteLine("Developer was deleted.");
        }
        else{
            System.Console.WriteLine("Developer failed to be removed.");
        }

        PressAnyKeyToContinue();

    }

    private void AddDevToDatabase()
    {
        Console.Clear();
        var newDeveloper = new Developer();

        System.Console.WriteLine("Enter the new developer's first name.");
        newDeveloper.FirstName = Console.ReadLine();

        System.Console.WriteLine("Enter the developer's last name.");
        newDeveloper.LastName = Console.ReadLine();

        System.Console.WriteLine("Does the developer have Pluralsight access? y/n");
        var pluralSightAccess = Console.ReadLine();
        if(pluralSightAccess == "Y".ToLower())
        {
            newDeveloper.HasPluralsight = true;
        }
        else
        {
            newDeveloper.HasPluralsight = false;
        }

        bool success = _dRepo.AddDevToDatabase(newDeveloper);

        System.Console.WriteLine($"{newDeveloper.FirstName} {newDeveloper.LastName} has been added.");

        PressAnyKeyToContinue();

        
    }

    private void AllDevelopers()
    {
        Console.Clear();
        System.Console.WriteLine("---Developers Listing---\n");
        var devsInDB = _dRepo.GetAllDevelopers();
        Console.Clear();

        foreach(var developer in devsInDB)
        {
            DisplayDeveloperInfo(developer);
        }


        PressAnyKeyToContinue();
    }


    private void DisplayDevelopers(Developer developer)
    {
        System.Console.WriteLine($" ID: {developer.DevID} --- Name: {developer.FirstName} {developer.LastName}");
    }

    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thanks!!!");
        PressAnyKeyToContinue();
        return false;
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private void SeedData()
    {
        var jake = new Developer("Jake", "Doe" , true);
        var alex = new Developer("Alex", "Brown" ,false);
        var julia = new Developer("Julia", "French", false);
        var marie = new Developer("Marie", "Doe", true);

        _dRepo.AddDevToDatabase(jake);
        _dRepo.AddDevToDatabase(alex);
        _dRepo.AddDevToDatabase(julia);
        _dRepo.AddDevToDatabase(marie);

        var team1 = new DevTeam("Team A");
        var team2 = new DevTeam("Team B");
        var team3 = new DevTeam("Team C");
        var team4 = new DevTeam("Team D");

        _tRepo.AddTeamToDatabase(team1);
        _tRepo.AddTeamToDatabase(team2);
        _tRepo.AddTeamToDatabase(team3);
        _tRepo.AddTeamToDatabase(team4);
        


    }

    
}
