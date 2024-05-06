using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

[assembly: InternalsVisibleTo("cis237-assignment-4-unit-test")]
namespace cis237_assignment_4
{
    internal class UserInterface
    {
        /// <summary>
        /// Displays a line to the console
        /// </summary>
        /// <param name="line"></param> The line to display
        public void DisplayLine(string line)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(line);
            Console.ResetColor();
        }

        // METHODS
        /// <summary>
        /// Acquires information for the new droid from the user. All information is collected as a string
        /// it will be converted before object instantiation in the droid collection.
        /// </summary>
        /// <returns>Returns a string containing all information gathered from the user</returns>
        public string[] GetNewItemInformation()
        {
            const string ADD_1 = "Protocol";
            const string ADD_2 = "Utility";
            const string ADD_3 = "Janitor";
            const string ADD_4 = "Astromech";

            // Options for each droid model
            string[] droidOptions = { "Protocol", "Utility", "Janitor", "Astromech" };
            // Options for each material the droid can be made from
            string[] materialOptions = { "Besker", "Chromium", "Cortosis", "Electrum" };
            // Options for each color the droid can be made from
            string[] colorOptions = { "Gold", "Silver", "Blue", "White" };

            // Gets the droid model
            string droidOption = this.GetOption("Pick An Option", droidOptions);
            // Gets the droid material
            string material = this.GetOption("Pick An Option", materialOptions);
            // Gets the droid color
            string color = this.GetOption("Pick An Option", colorOptions);

            // Checks for the droid model to be added to determine which information to be gathered
            if (droidOption == ADD_1)
            {
                string numOfLanguages = this.GetInt("How Many Languages Should The Droid Speak");

                // A string containing all droid options
                return new string[] { droidOption, 
                                      material, 
                                      color, 
                                      numOfLanguages};
            }
            if (droidOption == ADD_2)
            {
                string toolBox = this.GetBool("Should The Droid Have A Toolbox? T/F");
                string computerConnection = this.GetBool("Should The Droid Allow Computer Connections? T/F");
                string scanner = this.GetBool("Should The Droid Have A Scanner? T/F");

                // A string containing all droid options
                return new string[] { droidOption, 
                                      material, 
                                      color,        
                                      toolBox, 
                                      computerConnection,  
                                      scanner };
            }
            if (droidOption == ADD_3)
            {
                string toolBox = this.GetBool("Should The Droid Have A Toolbox? T/F");
                string computerConnection = this.GetBool("Should The Droid Allow Computer Connections? T/F");
                string scanner = this.GetBool("Should The Droid Have A Scanner? T/F");
                string broom = this.GetBool("Should This Droid Have A Broom? T/F");
                string vacuum = this.GetBool("Should This Droid Have A Vacuum? T/F");

                // A string containing all droid options
                return new string[] { droidOption, 
                                      material, 
                                      color, 
                                      toolBox, 
                                      computerConnection, 
                                      scanner, 
                                      broom, 
                                      vacuum };
            }
            if (droidOption == ADD_4)
            {
                string toolBox = this.GetBool("Should The Droid Have A Toolbox? T/F");
                string computerConnection = this.GetBool("Should The Droid Allow Computer Connections? T/F");
                string scanner = this.GetBool("Should The Droid Have A Scanner? T/F");
                string navigation = this.GetBool("Should This Droid Navigate? T/F");
                string numberShips = this.GetInt("How Many Ships Will This Droid Work On?");

                // A string containing all droid options
                return new string[] { droidOption, 
                                      material, 
                                      color, 
                                      toolBox, 
                                      computerConnection, 
                                      scanner, 
                                      navigation, 
                                      numberShips }; ;
            }

            // Return null if a droid model is not selected
            return null;
        }

        /// <summary>
        /// Displays a string to the user. 
        /// </summary>
        /// <param name="field"></param> A string to be displayed
        public void DisplayAllItems(string field)
        {
            // If the string is empty display nothing
            if ((field == string.Empty) || 
                (field == null) || 
                (field == ""))
            {
                this.DisplayError("Nothing To Display");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(field);
                string line = "End List";
                this.DisplayLine(line);
                Console.ResetColor(); 
            }
        } 

        /// <summary>
        /// Prompts the user for options.
        /// </summary>
        /// <param name="field"></param> A string output to the user asking which item to selected
        /// <param name="options"></param> A string array containing a list of options for the user to pick
        /// <returns>A string containing the value selected by the user</returns>
        public string GetOption(string field, string[] options)
        {
            string value = null;
            int option = 0;
            bool valid = false;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Output the options to the console
            for (int cv = 0; cv <= options.Length - 1; ++cv)
            {
                Console.WriteLine(Convert.ToString(cv) + "  " + options[cv]);
            }

            Console.WriteLine(field);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------");
            Console.Write(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ");
            Console.ResetColor();

            // Test if the user has picked a valid option loop until they do
            while (!valid)
            {
                try
                {
                    // Check that the input is a number
                    string input = this.GetInput();
                    option = int.Parse(input);

                    // Check if that number is within the bounds of the array
                    if (option < options.Length)
                    {
                        // Return the value and allow the loop to exit
                        value = options[option];
                        valid = true;
                    }
                    else
                    {
                        // Display an error if the number is outside the array
                        this.DisplayError("Pick A Valid Option");
                    }
                }
                catch (Exception)
                {
                    // Catch an exception if the string entered is not a number
                    this.DisplayError("Pick A Valid Option");
                }
            }

            Console.Clear();

            return value;
        }

        /// <summary>
        /// Displays an error.
        /// </summary>
        /// <param name="error"></param> A string containing the error to display
        private void DisplayError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(error);
            Console.ResetColor();
        }

        /// <summary>
        /// Prompts the user to enter an int. 
        /// </summary>
        /// <param name="field"></param> The prompt to display to the user
        /// <returns>The int as a string</returns>
        private string GetInt(string field)
        {
            int value = 0;
            bool valid = false;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(field);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------");
            Console.Write(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ");
            Console.ResetColor();

            // Loop until the value entered is an int
            while (!valid)
            {
                try
                {
                    // Try converting the value to an int
                    string input = this.GetInput();
                    value = int.Parse(input);
                    valid = true;
                }
                // Throw an error if the value is not an int
                catch (Exception)
                {
                    this.DisplayError("Enter A Valid Int");
                }
            }

            Console.Clear();

            // Return the value as an int
            return value.ToString();
        }

        /// <summary>
        /// Prompts the user to enter a bool. 
        /// </summary>
        /// <param name="field"></param> The prompt to display to the user
        /// <returns>The bool value as an int</returns>
        private string GetBool(string field)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(field);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------");
            Console.Write(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ");
            Console.ResetColor();

            string value = this.GetInput();

            // Loop until the user enters T or F
            while (value != "T" && 
                   value != "F" && 
                   value != "t" && 
                   value != "f")
            {
                // Show an error if user didnt enter T or F
                this.DisplayError("Enter T Or F");
                value = this.GetInput();
            }

            // Assigns a bool value to the return variable depending on user input
            if (value == "T" || value == "t")
            {
                value = "true";
            }

            // Assigns a bool value to the return variable depending on user input
            if (value == "F" || value == "f")
            {
                value = "false";
            }

            Console.Clear();

            return value;
        }

        /// <summary>
        /// Prompts the user to enter a decimal.
        /// </summary>
        /// <param name="field"></param> The prompt to be displayed to the user
        /// <returns>A string value containing the decimal</returns>
        private string GetDecimal(string field)
        {
            decimal value = 0.0m;
            bool valid = false;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(field);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------");
            Console.Write(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ");
            Console.ResetColor();

            // Loop until the user enters a valid decimal
            while (!valid)
            {
                try
                {
                    string input = this.GetInput();
                    value = decimal.Parse(input);
                    valid = true;
                }
                // Show an error if the value entered is not a decimal
                catch (Exception)
                {
                    this.DisplayError("Enter A Valid Decimal");
                }
            }

            Console.Clear();

            // Returns the decimal value as a string
            return value.ToString();
        }

        /// <summary>
        /// Reads input from the user 
        /// </summary>
        /// <returns>The input from the user</returns>
        private string GetInput()
        {
            string input = Console.ReadLine();

            // Loops until the input from user isnt empty or white space
            while (string.IsNullOrWhiteSpace(input))
            {
                // Show an error if the input is empty 
                this.DisplayError("Input Cannot Be Empty");

                input = Console.ReadLine();
            }

            return input;
        }

        // CONSTRUCTORS
        /// <summary>
        /// Instantiates the user input
        /// </summary>
        public UserInterface() { } 
    }
}
