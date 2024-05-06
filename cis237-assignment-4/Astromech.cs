using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("cis237-assignment-4-unit-test")]
namespace cis237_assignment_4
{
    internal class Astromech : Utility
    {
        // BACKING FIELDS
        private decimal _COST_PER_SHIP = 150m;
        private bool _navigation;
        private int _numberShips;

        // PROPERTIES
        public bool Navigation
        {
            get { return _navigation; }
            set { _navigation = value; }
        }

        public int NumberShips
        {
            get { return _numberShips; }
            set { _numberShips = value; }
        }

        // METHODS
        /// <summary>
        /// Overides tostring. Calls the tostring method all the way back to the 
        /// droid class then concatenates the astromech options on
        /// </summary>
        /// <returns>A string containing droid information</returns>
        public override string ToString()
        {
            // Calls the tostring method all the way back to the droid class then concatenates the astromech options on
            return base.ToString() + Environment.NewLine +
                   $"Navigation: {this.Navigation}" + Environment.NewLine +
                   $"Number Of Ships: {this.NumberShips}";
        }

        /// <summary>
        /// Calculates the total cost for all options selected for the droid. Overrides the droid class calculatetotalcost method.
        /// Sets the total cost property of the droid class
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            decimal optionCosts = base.CalculateOptions(Navigation);
            decimal shipCosts = base.CalculateOptions(_COST_PER_SHIP, this.NumberShips);
            TotalCost = optionCosts + shipCosts + base.TotalCost;
        }

        // CONSTRUCTOR
        /// <summary>
        /// Instantiates the astromech droid object. Then calculates the total cost for the any addons for the droid from
        /// back up the inheritance chain.
        /// </summary>
        /// <param name="model"></param> String value conaining the model
        /// <param name="material"></param> string value containing the material
        /// <param name="color"></param> String value containing the color 
        /// <param name="toolBox"></param> Bool value signifying if the droid has a toolbox
        /// <param name="computerConnection"></param> Bool value signifying if the droid has a computer connection
        /// <param name="scanner"></param> Bool value signifying if the droid has a scanner
        /// <param name="navigation"></param> Bool value signifying if the droid navigates
        /// <param name="numberShips"></param> Int value signifying how many ships the droid will work on
        public Astromech(string model,
                         string material,
                         string color,
                         bool toolBox,
                         bool computerConnection,
                         bool scanner,
                         bool navigation,
                         int numberShips) : base(model,
                                                 material,
                                                 color,
                                                 toolBox,
                                                 computerConnection,
                                                 scanner)
        {
            this.Navigation = navigation;
            this.NumberShips = numberShips;
            this.CalculateTotalCost();
        }

    }
}