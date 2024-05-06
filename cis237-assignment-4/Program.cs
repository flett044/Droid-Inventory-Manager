using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cis237_assignment_4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string LIST = "List Droid";
            const string ADD = "Add New";
            const string SORT = "Sort";
            const string EXIT = "Exit";
            const int DROID_COLLECTION_SIZE = 100;
            const string BY_MODEL = "Model";
            const string BY_TOTALCOST = "TotalCost";

            // Main menu options
            string[] menuOptions = { "List Droid", "Add New", "Sort", "Exit" };

            // Sort menu options
            string[] sortOptions = { "Model", "TotalCost" };

            UserInterface ui = new UserInterface();
            DroidCollection droids = new DroidCollection(DROID_COLLECTION_SIZE);

            string userInput = ui.GetOption("Pick An Option", menuOptions);

            while (userInput != EXIT)
            {
                switch (userInput)
                {
                    case LIST:
                        {
                            // Converts droid collection to a string
                            string droidsAsString = droids.ToString();
                            ui.DisplayAllItems(droidsAsString);
                            break;
                        }
                    case ADD:
                        {
                            // Gets options for a new droid
                            string[] newDroid = ui.GetNewItemInformation();
                            // Add the new droid to the array
                            droids.NewDroid(newDroid);
                            ui.DisplayLine("Droid Added");
                            break;
                        }
                    case SORT:
                        {
                            userInput = ui.GetOption("Sort By", sortOptions);

                            switch (userInput)
                            {
                                case BY_MODEL:
                                    {
                                        // Sort by model
                                        droids.SortByModel();
                                        ui.DisplayLine("Sort Complete");
                                        break;
                                    }
                                case BY_TOTALCOST:
                                    {
                                        // sort by total cost
                                        droids.SortByTotalCost();
                                        ui.DisplayLine("Sort Complete");
                                        break;
                                    }
                                default:
                                    {
                                        // Show an error if no option is picked
                                        userInput = ui.GetOption("Pick An Option", sortOptions);
                                        break;
                                    }
                            }

                            break;
                        }
                    default:
                        {
                            // Show an error if no option is picked
                            userInput = ui.GetOption("Pick An Option", menuOptions);
                            break;
                        }
                }

                // Show an error if no option is selected
                userInput = ui.GetOption("Pick An Option", menuOptions);
            }
        }
    }
}
