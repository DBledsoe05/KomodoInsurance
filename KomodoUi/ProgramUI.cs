
using DeveloperPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoUi
{
    class ProgramUI
    {

        public void Run()
        {
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
                    "1. Create New Content\n" +
                    "2. View all Content\n" +
                    "3. View Content By Title\n" +
                    "4. Update Existing Content\n" +
                    "5. Delete Existing Content\n" +
                    "6. Exit");

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
                        DisplayContentByTitle();
                        break;
                    case "4":
                        UpdateExistingContent();
                        break;
                    case "5":
                        DeleteExistingContent();
                        break;
                    case "6":
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

        //New
        private void CreateNewContent()
        {
            Developers newContent = new Developers();
        }

        //View
        private void DisplayAllContent()
        {

        }

        //View Existing
        private void DisplayContentByTitle()
        {

        }

        //Update Existing Content
        private void UpdateExistingContent()
        {

        }

        //Delete Conten
        private void DeleteExistingContent()
        {

        }
    }
}
