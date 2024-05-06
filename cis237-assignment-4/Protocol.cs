using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("cis237-assignment-4-unit-test")]
namespace cis237_assignment_4
{
    internal class Protocol : Droid
    {
        // BACKING FIELDS
        private const decimal _COST_PER_LANGUAGE = 100m;
        private int _numberLanguages;

        // PROPERTIES
        public int NumberLanguages
        {
            get { return _numberLanguages; }
            set { _numberLanguages = value; }
        }

        // Overrides the base class total cost property
        public override decimal TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        // METHODS
        /// <summary>
        /// Converts the droid object to a to string. Calls the droid class to string then concatenates on the 
        /// new options from this class.
        /// </summary>
        /// <returns>A string containg the droid as a string</returns>
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                   $"Number Of Languages: {this.NumberLanguages.ToString()}";
        }

        /// <summary>
        /// Overrides the total cost method of the base class. Calculates the total cost of the all options selected. Then sets
        /// the total cost property.
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            TotalCost = base.CalculateOptions(_COST_PER_LANGUAGE, _numberLanguages) + base.TotalCost;
        }

        // CONSTRUCTORS
        /// <summary>
        /// Instantiates the droid object. Then calculates the total cost for the any addons for the droid from
        /// back up the inheritance chain.
        /// </summary>
        /// <param name="model"></param> A string contaiming the model
        /// <param name="material"></param> A string containing the material
        /// <param name="color"></param> A string containing the color
        /// <param name="numberLanguages"></param> An int specifying the number of languages the droid speaks
        public Protocol(string model, 
                        string material, 
                        string color, 
                        int numberLanguages) : base(model, 
                                                    material, 
                                                    color)
        {
            this.NumberLanguages = numberLanguages;
            this.CalculateTotalCost();
        }
    }
}
