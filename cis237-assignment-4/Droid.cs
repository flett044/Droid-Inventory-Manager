using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("cis237-assignment-4-unit-test")]
namespace cis237_assignment_4
{
    internal abstract class Droid : IDroid
    {
        // BACKING FIELDS
        private const decimal _BESKAR_COST = 10.0m;
        private const decimal _CHOMIUM_COST = 15.0m;
        private const decimal _CORTOSIS_COST = 20.0m;
        private const decimal _ELECTRUM_COST = 25.0m;
        private const decimal _PRICE_PER_OPTION = 10.0m;
        private const decimal _PROTOCOL_COST = 100.0m;
        private const decimal _ASTROMECH_COST = 500.0m;
        private const decimal _JANITOR_COST = 200.0m;
        private const decimal _UTILITY_COST = 400.0m;
        private decimal _materialCost;
        private decimal _modelCost;
        private string _model;
        private string _material;
        private string _color;
        protected decimal _totalCost;

        // PROPERTIES
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public string Material
        {
            get { return _material; }
            set {  _material = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        // Can be overriden in child classes
        public virtual decimal TotalCost 
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        public decimal MaterialCost
        {
            get { return _materialCost; }
            set { _materialCost = value; }
        }

        public decimal ModelCost
        {
            get { return _modelCost; }
            set { _modelCost = value; }
        }

        // METHODS
        /// <summary>
        /// Overrides the tostring method
        /// </summary>
        /// <returns>A string containg the droids information</returns>
        public override string ToString()
        {
            return Environment.NewLine +
                   Environment.NewLine +
                   $"Model: {this.Model}" + Environment.NewLine +
                   $"Material: {this.Material}" + Environment.NewLine +
                   $"Color: {this.Color}" + Environment.NewLine +
                   $"Total Cost: {this.TotalCost.ToString("C")}";
        }

        /// <summary>
        /// Calculates the total cost of the droid. Can be overriden in child classes
        /// </summary>
        public virtual void CalculateTotalCost()
        {
            this.MaterialCost = this.GetMaterialCost();
            this.ModelCost = this.GetModelCost();
            this.TotalCost = this.MaterialCost + this.ModelCost;
        }

        /// <summary>
        /// Calculates options for each droid. Counts how many options are true then calculates 
        /// the total for the options using a constant. 
        /// Called in child classes later using base keyword. 
        /// </summary>
        /// <param name="options"></param> Accepts multiple bool options
        /// <returns>Returns a decimal containing the calculate options cost</returns>
        protected decimal CalculateOptions(params bool[] options)
        {
            int count = 0;

            foreach (bool option in options)
            {
                if (option)
                {
                    count++;
                }
            }

            return count * _PRICE_PER_OPTION;
        }

        /// <summary>
        /// Calculates the total cost of the options passed to it. Called in later child classes using the base keyword. 
        /// </summary>
        /// <param name="priceConstant"></param> A decimal containing the price of the option
        /// <param name="count"></param> An int counting how many options where selected
        /// <returns>A decimal containing the calculated price for the options</returns>
        protected decimal CalculateOptions(decimal priceConstant, int count)
        {
            return priceConstant * count;
        }
        
        /// <summary>
        /// Calculates the cost of the material the droid is being made out of. Reads the material property of the instantiated
        /// droid.
        /// </summary>
        /// <returns>A decimal containg the cost of the material</returns>
        private decimal GetMaterialCost()
        {
            decimal cost;
            
            switch (this.Material)
            {
                case ("Besker"):
                    {
                        cost = _BESKAR_COST;

                        break;
                    }
                case ("Chromium"):
                    {
                        cost = _CHOMIUM_COST;

                        break;
                    }
                case ("Cortosis"):
                    {
                        cost = _CORTOSIS_COST;

                        break;
                    }
                case ("Electrum"):
                    {
                        cost = _ELECTRUM_COST;

                        break;
                    }
                default:
                    {
                        cost = 0.0m;

                        break;
                    }
            }

            return cost;
        }

        /// <summary>
        /// Calculates the model cost of the droid by reading the droids model property. 
        /// </summary>
        /// <returns>Returns a decimal containg the price of the model</returns>
        private decimal GetModelCost()
        {
            decimal cost;

            switch (this.Model)
            {
                case ("Protocol"):
                    {
                        cost = _PROTOCOL_COST;

                        break;
                    }
                case ("Astromech"):
                    {
                        cost = _ASTROMECH_COST;

                        break;
                    }
                case ("Janitor"):
                    {
                        cost = _JANITOR_COST;

                        break;
                    }
                case ("Utility"):
                    {
                        cost = _UTILITY_COST;

                        break;
                    }
                default:
                    {
                        cost = 0.0m;

                        break;
                    }
            }

            return cost;
        }

        /// <summary>
        /// Compares the current droid total cost to another droids total
        /// </summary>
        /// <param name="obj"></param> Current droid object
        /// <returns>1 if object is null or an int specifying if the object comparision is correct</returns>
        /// <exception cref="Exception"></exception> Throws an exception the obj is not a droid
        public int CompareTo(object obj)
        {
            // Cant be null
            if (obj == null)
            {
                return 1;
            }

            Droid otherDroid = obj as Droid;

            if (otherDroid != null)
            {
                return this.TotalCost.CompareTo(otherDroid.TotalCost);
            }
            else
            {
                throw new Exception("Object Not Droid");
            }
        }

        // CONSTRUCTORS
        /// <summary>
        /// Instantiates the droid object
        /// </summary>
        /// <param name="model"></param> A string containing the model of the droid
        /// <param name="material"></param> A string containing the material of the droid
        /// <param name="color"></param> A string containing the color of the droid
        public Droid(string model, string material, string color) 
        {
            this.Model = model;
            this.Material = material;
            this.Color = color;
        }
    }
}
