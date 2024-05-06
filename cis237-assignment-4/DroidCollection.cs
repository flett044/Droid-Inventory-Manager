using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("cis237-assignment-4-unit-test")]
namespace cis237_assignment_4
{
    internal class DroidCollection
    {
        // BACKING FIELDS
        private Droid[] droids;

        // Count how many droids are in the array
        private int count = 0;

        // METHODS
        /// <summary>
        /// Overrides the to string method to returning a string containin the droid objects
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string droidsString = "";

            for (int cv = 0; cv < droids.Length; ++cv)
            {
                if (droids[cv] != null)
                {
                    droidsString += droids[cv].ToString();
                }
            }

            return droidsString;
        }

        /// <summary>
        /// Sorts the droid collection by model using a bucket sort
        /// </summary>
        public void SortByModel()
        {
            BucketSort bucketSort = new BucketSort();
            bucketSort.Sort(droids);
        }

        /// <summary>
        /// Sorts the droid collection by total cost using a merge sort
        /// </summary>
        public void SortByTotalCost()
        {
            MergeSort mergeSort = new MergeSort();
            // Create an aux array to hold droid collection
            IComparable[] droidsAux = new IComparable[droids.Length];
            // Pass droids array, droids aux array, low value (starting value of the sort), and droids length to sort method
            mergeSort.Sort(droids, droidsAux, 0, droids.Length - 1);
        }

        /// <summary>
        /// Adds a new droid to the droid collection. Reads the first slot of the array coming in to determine which 
        /// method to use to instantiate the object. 
        /// </summary>
        /// <param name="droidOptions"></param> An array of strings containing the properties for the droid to be created
        public void NewDroid(params string[] droidOptions)
        {
            const string ADD_1 = "Protocol";
            const string ADD_2 = "Utility";
            const string ADD_3 = "Janitor";
            const string ADD_4 = "Astromech";

            // Keeps track of the  next empty slot in the array
            int index = count + 1;

            switch (droidOptions[0])
            {
                case (ADD_1):
                    {
                        this.AddDroid(index,
                                      droidOptions[0],
                                      droidOptions[1], 
                                      droidOptions[2], 
                                      Convert.ToInt32(droidOptions[3]));
                        break;
                    }
                case (ADD_2):
                    {
                        this.AddDroid(index,
                                      droidOptions[0],
                                      droidOptions[1], 
                                      droidOptions[2], 
                                      Convert.ToBoolean(droidOptions[3]), 
                                      Convert.ToBoolean(droidOptions[4]), 
                                      Convert.ToBoolean(droidOptions[5]));
                        break;
                    }
                case (ADD_3):
                    {
                        this.AddDroid(index,
                                      droidOptions[0],
                                      droidOptions[1],
                                      droidOptions[2],
                                      Convert.ToBoolean(droidOptions[3]),
                                      Convert.ToBoolean(droidOptions[4]),
                                      Convert.ToBoolean(droidOptions[5]),
                                      Convert.ToBoolean(droidOptions[6]),
                                      Convert.ToBoolean(droidOptions[7]));

                        break;
                    }
                case (ADD_4):
                    {
                        this.AddDroid(index,
                                      droidOptions[0],
                                      droidOptions[1],
                                      droidOptions[2],
                                      Convert.ToBoolean(droidOptions[3]),
                                      Convert.ToBoolean(droidOptions[4]),
                                      Convert.ToBoolean(droidOptions[5]),
                                      Convert.ToBoolean(droidOptions[6]),
                                      Convert.ToInt32(droidOptions[7]));
                        break;
                    }
            }

            ++count;
        }

        /// <summary>
        /// Instantiates a droid into the array.
        /// </summary>
        /// <param name="index"></param> The index to add the droid as an int
        /// <param name="model"></param> The model of the droid as a string
        /// <param name="material"></param> The material of the droid as a string
        /// <param name="color"></param> The color of the droid as a string
        /// <param name="numberLanguages"></param> The number of languages the droid should speak as an int
        private void AddDroid(int index,
                              string model,
                              string material, 
                              string color, 
                              int numberLanguages)
        {
            try
            {
                droids[index] = new Protocol(model,
                                             material, 
                                             color, 
                                             numberLanguages);
            }
            // Catch an exception if the array is full
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Array Full");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Instantiates a droid into the array.
        /// </summary>
        /// <param name="index"></param> The slot the droid should be added in as an int
        /// <param name="model"></param> The model of the droid as a string
        /// <param name="material"></param> The material of the droid as a string
        /// <param name="color"></param> The color of the droid as a string
        /// <param name="toolBox"></param> A bool value specifying if the droid has a toolbox
        /// <param name="computerConnection"></param> A bool value specifying if the droid has a computer connection
        /// <param name="scanner"></param> A bool value specifying if the droid has a scanner
        private void AddDroid(int index,
                              string model,
                              string material, 
                              string color, 
                              bool toolBox, 
                              bool computerConnection, 
                              bool scanner)
        {
            try
            {
                droids[index] = new Utility(model,
                                            material, 
                                            color, 
                                            toolBox, 
                                            computerConnection, 
                                            scanner);
            }
            // Catch an exception if the array is full
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Array Full");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Instantiates a droid into the array
        /// </summary>
        /// <param name="index"></param> The slot the droid should be added in as an int
        /// <param name="model"></param> The model of the droid as a string
        /// <param name="material"></param> The material of the droid as a string
        /// <param name="color"></param> The color of the droid as a string
        /// <param name="toolbox"></param> Specifying if the droid has a toolbox as a bool
        /// <param name="computerConnection"></param> Specifying if the droid has a computer connecton as a bool
        /// <param name="scanner"></param> Specifying if the droid has a scanner as a bool
        /// <param name="broom"></param> Specifying if the droid has a broom as a bool
        /// <param name="vacuum"></param> Specifying if the droid has a vacuum as a bool
        private void AddDroid(int index,
                              string model,
                              string material, 
                              string color, 
                              bool toolbox, 
                              bool computerConnection, 
                              bool scanner, 
                              bool broom, 
                              bool vacuum)
        {
            try
            {
                droids[index] = new Janitor(model, 
                                            material, 
                                            color, 
                                            toolbox, 
                                            computerConnection, 
                                            scanner, 
                                            broom, 
                                            vacuum);
            }
            // Catch an exception if the array is full
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Array Full");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Instantiates a droid into the array
        /// </summary>
        /// <param name="index"></param> The slot to add the droid in as an int
        /// <param name="model"></param> The model of the droid as a string
        /// <param name="material"></param> The material of the droid as a string
        /// <param name="color"></param> The color of the droid as a string
        /// <param name="toolbox"></param> Specifying if the droid has a toolbox as a bool
        /// <param name="computerConnection"></param> Specifying if the droid has computer connection as a bool
        /// <param name="scanner"></param> Specifying if the droid has a scanner as a bool
        /// <param name="navigation"></param> Specifying if the droid navigates ships as a bool
        /// <param name="numberShips"></param> Specifying how many ships the droid will work on as an int
        private void AddDroid(int index,
                              string model,
                              string material, 
                              string color, 
                              bool toolbox, 
                              bool computerConnection, 
                              bool scanner, 
                              bool navigation, 
                              int numberShips)
        {
            try
            {
                droids[index] = new Astromech(model,
                                              material, 
                                              color, 
                                              toolbox, 
                                              computerConnection, 
                                              scanner, 
                                              navigation, 
                                              numberShips);
            }
            // Catch an exception if the array is full
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Array Full");
                Console.ResetColor();
            }
        }
       
        /// <summary>
        /// Add test data to the array 
        /// </summary>
        private void AddTestData()
        {

            this.NewDroid("Protocol", "Besker", "Gold", "3");
            this.NewDroid("Astromech", "Chromium", "Gold", "true", "false", "true", "false", "6");
            this.NewDroid("Utility", "Cortosis", "Gold", "true", "false", "true");
            this.NewDroid("Janitor", "Electrum", "Gold", "false", "true", "true", "true", "false");
            this.NewDroid("Protocol", "Besker", "Gold", "3");
            this.NewDroid("Astromech", "Besker", "Gold", "true", "true", "true", "true", "3");
            this.NewDroid("Utility", "Besker", "Gold", "true", "true", "true");
            this.NewDroid("Janitor", "Besker", "Gold", "true", "true", "true", "true", "true");
        }

        // CONSTRUCTORS
        /// <summary>
        /// Instanties a collection of droids and adds test data to it
        /// </summary>
        /// <param name="size"></param> The size of the array as an int
        public DroidCollection(int size) 
        {
            this.droids = new Droid[size];
            this.AddTestData();
        }
    }
}
