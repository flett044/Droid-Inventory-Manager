using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("cis237-assignment-4-unit-test")]
namespace cis237_assignment_4
{
    internal class Utility : Droid
    {
        // BACKING FIELDS
        private bool _toolBox;
        private bool _computerConnection;
        private bool _scanner;

        // PROPERTIES
        // Overrides the total cost from the base clas
        public override decimal TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        public bool ToolBox 
        {
            get { return _toolBox; }
            set { _toolBox = value; }
        }
        public bool ComputerConnection 
        {
            get { return _computerConnection; }
            set { _computerConnection = value; }
        }
        public bool Scanner 
        {
            get { return _scanner; }
            set { _scanner = value; }
        }   

        // METHODS
        /// <summary>
        /// Calls the base to string then concatenates the new options onto it.
        /// </summary>
        /// <returns>A string containing the droid object as a string</returns>
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                   $"ToolBox: {this.ToolBox}" + Environment.NewLine +
                   $"Computer Connection: {this.ComputerConnection}" + Environment.NewLine +
                   $"Scanner: {this.Scanner}";
        }

        /// <summary>
        /// Overrides the base class calculate total cost. Calculates the cost of all options on the droid. Then sets the 
        /// total cost property to that value. 
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            decimal optionsCost = base.CalculateOptions(ToolBox, ComputerConnection, Scanner);
            TotalCost =  optionsCost + base._totalCost;
        }

        // CONSTRUCTORS
        /// <summary>
        /// Instantiates the droid the calculates the total cost. 
        /// </summary>
        /// <param name="model"></param> A string containing the model
        /// <param name="material"></param> A string containing the material
        /// <param name="color"></param> A string containing the color
        /// <param name="toolBox"></param> A bool value specifying if the droid has a toolbox
        /// <param name="computerConnection"></param> A bool value specifying if the droid has a computer connection
        /// <param name="scanner"></param> A bool value specifying if the droid has a scanner
        public Utility(string model, 
                       string material, 
                       string color, 
                       bool toolBox, 
                       bool computerConnection, 
                       bool scanner) : base(model, 
                                            material, 
                                            color)
        {
            this.ToolBox = toolBox;
            this.ComputerConnection = computerConnection;
            this.Scanner = scanner;
            this.CalculateTotalCost();
        }
    }
}
