using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static  System.Runtime.InteropServices.JavaScript.JSType;

[assembly: InternalsVisibleTo("cis237-assignment-4-unit-test")]
namespace cis237_assignment_4
{
    internal class MergeSort : IMergeSort
    {
        // METHODS
        /// <summary>
        /// Sorts the in coming IComparable array using a merge sort
        /// </summary>
        /// <param name="collection"></param> Collection to be sorted
        /// <param name="aux"></param> Auxiliary array used during process
        /// <param name="lo"></param> Starting value of the array
        /// <param name="hi"></param> Ending value of the array
        public void Sort(IComparable[] collection, IComparable[] aux, int lo, int hi)
        {
            // Calculate the mid value then start sorting
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            // Recursively call the sort and merge methods until everything is sorted
            Sort(collection, aux, lo, mid);
            Sort(collection, aux, mid + 1, hi);
            Merge(collection, aux, lo, mid, hi);
        }

        /// <summary>
        /// Merge the collection with the aux array then check each value in the array and copy them 
        /// to the array they need to go to
        /// </summary>
        /// <param name="collection"></param> Array to be sorted
        /// <param name="aux"></param> Aux array used during sort
        /// <param name="lo"></param> Low value of the array
        /// <param name="mid"></param> Mid value of the array
        /// <param name="hi"></param> High value of the array
        private static void Merge(IComparable[] collection, IComparable[] aux, int lo, int mid, int hi)
        {
            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = collection[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;

            // Loop through both arrays checking each value and putting them in their respective order. 
            // Puts null at the beginning
            for (int cv = lo; cv <= hi; ++cv)
            {
                if (i > mid)
                {
                    collection[cv] = aux[j++];
                }
                else if (j > hi)
                {
                    collection[cv] = aux[i++];
                }
                else if (aux[i] == null)
                {
                    collection[cv] = aux[i++];
                }
                else if (aux[j] == null)
                {
                    collection[cv] = aux[j++];
                }
                // Compare the total costs
                else if (aux[j].CompareTo(aux[i]) < 0)
                {
                    collection[cv] = aux[j++];
                }
                else
                {
                    collection[cv] = aux[i++];
                }
            }
        }

        // CONSTRUCTORS
        public MergeSort() { }
    }
}
