using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("cis237-assignment-4-unit-test")]
namespace cis237_assignment_4
{
    internal class BucketSort : IBucketSort
    {
        // METHODS
        /// <summary>
        /// Sort an array of droids using a modified bucket sort
        /// </summary>
        /// <param name="droids"></param>
        /// <exception cref="Exception"></exception>
        public void Sort(Droid[] droids)
        {
            // Create the stacks
            IGenericLinkedListStack<Protocol> protocolStack = new GenericLinkedListStack<Protocol>();
            IGenericLinkedListStack<Astromech> astromechStack = new GenericLinkedListStack<Astromech>();
            IGenericLinkedListStack<Utility> utilityStack = new GenericLinkedListStack<Utility>();
            IGenericLinkedListStack<Janitor> janitorStack = new GenericLinkedListStack<Janitor>();

            // Create a droid queue
            IGenericLinkedListQueue<Droid> droidQueue = new GenericLinkedListQueue<Droid>();

            // Check each droid type in droids and push it into there respective queues
            for (int cv = 0; cv < droids.Length; ++cv)
            {
                if (droids[cv] != null)
                {
                    Type t = droids[cv].GetType();

                    if (t == typeof(Janitor))
                    {
                        janitorStack.Push((Janitor)droids[cv]);
                    }
                    else if (t == typeof(Astromech))
                    {
                        astromechStack.Push((Astromech)droids[cv]);
                    }
                    else if (t == typeof(Utility))
                    {
                        utilityStack.Push((Utility)droids[cv]);
                    }
                    else if (t == typeof(Protocol))
                    {
                        protocolStack.Push((Protocol)droids[cv]);
                    }
                    else
                    {
                        // Throw an exceptions of the droid doesnt match the type
                        throw new Exception("Invalid Droid Type");
                    }
                }
            }

            // Sort Order:
            // Astromech, Janitor, Utility, Protocol
            // Pop the droids off the stack and Enqueue them into droid queue
            while (!astromechStack.IsEmpty()) droidQueue.Enqueue(astromechStack.Pop());
            while (!janitorStack.IsEmpty()) droidQueue.Enqueue(janitorStack.Pop());
            while (!utilityStack.IsEmpty()) droidQueue.Enqueue(utilityStack.Pop());
            while (!protocolStack.IsEmpty()) droidQueue.Enqueue(protocolStack.Pop());

            // Overwrite initial droids array with sorted stack
            for (int cv = 0; cv < droids.Length && !droidQueue.IsEmpty(); ++cv)
            {
                if (droids[cv] != null)
                {
                    droids[cv] = droidQueue.Dequeue();
                }
            }
        }

        // CONSTRUCTORS
        public BucketSort() { }
    }
}
