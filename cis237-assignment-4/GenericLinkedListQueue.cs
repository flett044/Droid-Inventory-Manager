using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("cis237-assignment-4-unit-test")]
namespace cis237_assignment_4
{
    // METHODS
    internal class GenericLinkedListQueue<T> : IGenericLinkedListQueue<T>
    {
        // Create a node class holding a snippet of data and a next pointer
        private class Node
        {
            public T Value { get; }
            public Node Next { get; set; }

            public Node(T value, Node next = null)
            {
                this.Value = value;
                this.Next = next;
            }
        }

        private Node head = null; // The first element of the queue
        private Node tail = null; // The last element of the queue

        // The number of items in the queue
        public int Count { get; set; } = 0;

        /// <summary>
        /// Add an element to the end of the queue
        /// </summary>
        /// <param name="item"></param> The item to be added to the queue
        public void Enqueue(T item)
        {
            Node newNode = new Node(item);

            // If the head is null point to the tail and assign it to the newNode
            if (head == null)
            {
                head = tail = newNode;
            }
            // Assign the tail.next property to newNode and tail to newNode
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            // Increment the count because and object has been added to the queue
            Count++;
        }

        /// <summary>
        /// Remove and return the element at the front of the queue
        /// </summary>
        /// <returns>The value being removed from the queue</returns>
        /// <exception cref="Exception"></exception> Throw an exception of the queue is empty
        public T Dequeue()
        {
            if (head == null)
            {
                throw new Exception("The queue is empty.");
            }

            // Assign the value to the current head value
            T value = head.Value;
            // Move head to next value in the list
            head = head.Next;

            // If head is empty then tail empty therefore queue is empty
            if (head == null)
            {
                tail = null; // Empty
            }

            // Deincrement the count because an object has been removed from the queue
            Count--;

            return value;
        }

        /// <summary>
        /// Remove and return the element at the front of the queue
        /// </summary>
        /// <returns>The object on the top of the queue</returns>
        /// <exception cref="Exception"></exception> Throw an exception if the queues empty
        public T Peek()
        {
            if (head == null)
            {
                throw new Exception("The queue is empty.");
            }

            return head.Value;
        }

        /// <summary>
        /// Checks if the queue is empty. If the queue count is zero it must be empty
        /// </summary>
        /// <returns>A bool</returns>
        public bool IsEmpty() => Count == 0; // Sets isEmpty to true if count is 0
                                             // Lambda Operator
                                             // Input Parameters       Expression

        // CONSTRUCTORS
        public GenericLinkedListQueue() { }
    }
}
