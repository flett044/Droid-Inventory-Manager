using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("cis237-assignment-4-unit-test")]
namespace cis237_assignment_4
{
    internal class Janitor : Utility
    {
        // BACKING FIELDS
        private bool _broom;
        private bool _vacuum;

        // PROPERTIES
        public bool Broom
        {
            get { return _broom; }
            set { _broom = value; }
        }

        public bool Vacuum
        {
            get { return _vacuum; }
            set { _vacuum = value; }
        }

        // METHODS
        /// <summary>
        /// Overides the tostring method. Calls the tostring method all the way back to the droid class
        /// then concantenates the janitor options on.
        /// </summary>
        /// <returns>A string containing the droid object as a string</returns>
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                   $"Broom: {this.Broom}" + Environment.NewLine +
                   $"Vacuum: {this.Vacuum}";
        }

        /// <summary>
        /// Overrides the droid total cost. Calculates the cost of each option the sets the total cost property to the calculted
        /// value.
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            decimal optionsCost = base.CalculateOptions(Broom, Vacuum);
            TotalCost = optionsCost + base.TotalCost;
        }

        // CONSTRUCTORS
        /// <summary>
        /// Instanties the droid. Then calculates the total cost for the any addons for the droid from
        /// back up the inheritance chain.
        /// </summary>
        /// <param name="model"></param> The model as a string
        /// <param name="material"></param> The material as a string
        /// <param name="color"></param> The color as a string
        /// <param name="toolBox"></param> A bool specifying if the droid has a toolbox
        /// <param name="computerConnection"></param> A bool specifying if the droid has a computer connection
        /// <param name="scanner"></param> A bool value specify if the droid has a scanner
        /// <param name="broom"></param> A bool value specifying if the droid has a broom
        /// <param name="vacuum"></param> A bool value specifying if the droid has a vacuum
        public Janitor(string model, 
                       string material, 
                       string color, 
                       bool toolBox, 
                       bool computerConnection, 
                       bool scanner, 
                       bool broom, 
                       bool vacuum) : base(model,
                                           material, 
                                           color, 
                                           toolBox, 
                                           computerConnection, 
                                           scanner)
        {
            this.Broom = broom;
            this.Vacuum = vacuum;
            this.CalculateTotalCost();
        }

    }
}
