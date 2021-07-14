
using DeveloperPoco;
using DevTeamPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoUi
{
    class ProgramUI
    {
        private DevRepository _devRepo = new DevRepository();

        private DevTeamRepository _devTeamRepo = new DevTeamRepository();

        public void Run()
        {
            DeveloperList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {


                //Options for user
                Console.WriteLine("Main Menu:\n" +
                    "1. Create New Developer\n" +
                    "2. View all DevTeams\n" +
                    "3. View A Developer\n" +
                    "4. Update Existing Developer\n" +
                    "5. Delete Existing Developers\n" +
                    "6. Create New DevTeam\n" +
                    "7. Update DevTeam and add a Developer\n" +
                    "8. Exit");

                //Input from user
                string input = Console.ReadLine();

                //Evalute input and act

                switch (input)
                {
                    case "1":
                        CreateNewContent();
                        break;
                    case "2":
                        DisplayAllContent();
                        break;
                    case "3":
                        DisplayContentByDeveloper();
                        break;
                    case "4":
                        UpdateExistingContent();
                        break;
                    case "5":
                        DeleteExistingContent();
                        break;
                    case "6":
                        CreateNewDevTeam();
                        break;
                    case "7":
                        UpdateDevTeam();
                        break;
                    case "8":
                        //Exit
                        Console.WriteLine("Leaving Program");
                        keeprunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //New Developer
        private void CreateNewContent()
        {
            Console.Clear();
            Developers newContent = new Developers();

            //FirstName
            Console.WriteLine("Enter developers first name:");
            newContent.FirstName = Console.ReadLine();

            //LastName
            Console.WriteLine("Enter developers last name:");
            newContent.LastName = Console.ReadLine();

            //ID
            Console.WriteLine("Enter ID number:");
            string idIsString = Console.ReadLine();
            newContent.ID = int.Parse(idIsString);

            //PluralSight
            Console.WriteLine("Does the developer have PluralSight? (y/n)");
            string isPluralSight = Console.ReadLine().ToLower();

            if(isPluralSight == "y")
            {
                newContent.PluralSight = true;
            }
            else
            {
                newContent.PluralSight = false;
            }

            _devRepo.AddContentToList(newContent);
        }

        //Create DevTeam
        private void CreateNewDevTeam()
        {
            Console.Clear();
            DevTeam newContent = new DevTeam();

            //Team Name
            Console.WriteLine("Enter Team Name:");
            newContent.TeamName = Console.ReadLine();

            //Team ID
            Console.WriteLine("Enter the team's ID number:");
            string teamID = Console.ReadLine();
            newContent.TeamID = int.Parse(teamID);

            _devTeamRepo.AddContentToList(newContent);
        }

        //View All DevTeams
        private void DisplayAllContent()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetContentList();
            List<Developers> listOfDevelopers = _devRepo.GetContentList();

            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Team Name: {devTeam.TeamName}\n" +
                    $"Team ID: {devTeam.TeamID}\n");
            }

            foreach (Developers developers in listOfDevelopers)
            {
                Console.WriteLine($"First Name: {developers.FirstName}\n" +
                    $"Last Name: {developers.LastName}\n" +
                    $"PluralSight: {developers.PluralSight}\n");
            }
        }

        //View Existing Developer
        private void DisplayContentByDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Enter developer's first name:");
            string firstName = Console.ReadLine();
            Developers developers = _devRepo.GetDevelopersByFirstName(firstName);

            if(developers != null)
            {
                Console.Clear();
                Console.WriteLine($"First Name: {developers.FirstName}\n" +
                    $"Last Name: {developers.LastName}\n" +
                    $"ID: {developers.ID}\n" +
                    $"PluralSight: {developers.PluralSight}\n");
            }
            else
            {
                Console.WriteLine("No developer by that name.");
            }
        }

        //Update Existing Developer
        private void UpdateExistingContent()
        {
            Console.Clear();
            DisplayAllContent();
            Console.WriteLine("Enter the first name of the developer you want to update:");
            string oldDeveloper = Console.ReadLine();

            Developers newContent = new Developers();

            //FirstName
            Console.WriteLine("Enter developers first name:");
            newContent.FirstName = Console.ReadLine();

            //LastName
            Console.WriteLine("Enter developers last name:");
            newContent.LastName = Console.ReadLine();

            //ID
            Console.WriteLine("Enter ID number:");
            string idIsString = Console.ReadLine();
            newContent.ID = int.Parse(idIsString);

            //PluralSight
            Console.WriteLine("Does the developer have PluralSight? (y/n)");
            string isPluralSight = Console.ReadLine().ToLower();

            if (isPluralSight == "y")
            {
                newContent.PluralSight = true;
            }
            else
            {
                newContent.PluralSight = false;
            }

            // verify
            bool wasUpdated = _devRepo.UpdateExistingContent(oldDeveloper, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("Current developer was updated.");
            }
            else
            {
                Console.WriteLine("Could not update the current developer.");
            }
        }

        //Update DevTeam and add developer
        private void UpdateDevTeam()
        {
            Console.Clear();
            DisplayAllContent();
            Console.WriteLine("Enter the team name you want updated:");
            string oldDevTeam = Console.ReadLine();

            DevTeam newContent = new DevTeam();

            //Team Name
            Console.WriteLine("Enter team name (use uppercase for the first letter):");
            newContent.TeamName = Console.ReadLine();

            //Team ID
            Console.WriteLine("Enter the team's ID number:");
            string teamID = Console.ReadLine();
            newContent.TeamID = int.Parse(teamID);

            Developers newDeveloper = new Developers();

            //FirstName
            Console.WriteLine("Enter developers first name:");
            newDeveloper.FirstName = Console.ReadLine();

            //LastName
            Console.WriteLine("Enter developers last name:");
            newDeveloper.LastName = Console.ReadLine();

            //ID
            Console.WriteLine("Enter ID number:");
            string idIsString = Console.ReadLine();
            newDeveloper.ID = int.Parse(idIsString);

            //PluralSight
            Console.WriteLine("Does the developer have PluralSight? (y/n)");
            string isPluralSight = Console.ReadLine().ToLower();

            if (isPluralSight == "y")
            {
                newDeveloper.PluralSight = true;
            }
            else
            {
                newDeveloper.PluralSight = false;
            }

            // verify
            bool wasUpdated = _devTeamRepo.UpdateExistingContent(oldDevTeam, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("Current devTeam was updated.");
            }
            else
            {
                Console.WriteLine("Could not update the current devTeam.");
            }
        }

        //Delete Developer    
        private void DeleteExistingContent()
        {
            Console.Clear();

            DisplayAllContent();
            Console.WriteLine("\nEnter the first name of the developer you want to delete:");
            string input = Console.ReadLine();
            bool developerDeleted = _devRepo.RemoveContentFromList(input);

            if (developerDeleted)
            {
                Console.WriteLine("The current developer was deleted.");
            }
            else
            {
                Console.WriteLine("The developer was not deleted.");
            }
        }

        //See DevTeams and Developers method
        private void DeveloperList()
        {
            Developers phil = new Developers("Phill", "Colins", 3123, true);
            Developers bill = new Developers("Bill", "Johns", 4353, true);
            Developers don = new Developers("Don", "Thomas", 6453, true);

            DevTeam alpha = new DevTeam("Alpha", 5433);
            DevTeam beta = new DevTeam("Beta", 6754);
            DevTeam omega = new DevTeam("Omega", 5644);

            _devRepo.AddContentToList(phil);
            _devRepo.AddContentToList(bill);
            _devRepo.AddContentToList(don);

            _devTeamRepo.AddContentToList(alpha);
            _devTeamRepo.AddContentToList(beta);
            _devTeamRepo.AddContentToList(omega);
        }

    }
}
