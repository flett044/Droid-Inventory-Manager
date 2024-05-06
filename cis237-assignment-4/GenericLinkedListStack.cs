using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("cis237-assignment-4-unit-test")]
namespace cis237_assignment_4
{
    internal class GenericLinkedListStack<T> : IGenericLinkedListStack<T>
    {
        // Create a  node class to hold each snippet of data and a next pointer
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data)
            {
                this.Data = data;
                this.Next = null;
            }
        }

        private Node top;

        /// <summary>
        /// Check if the stack is empty. If top is null the list is empty
        /// </summary>
        /// <returns>A bool specifying if the stack is empty</returns>
        public bool IsEmpty()
        {
            return top == null;
        }

        /// <summary>
        ///  Add an item to the stack
        /// </summary>
        /// <param name="item"></param> The item to be added
        public void Push(T item)
        {
            var newNode = new Node(item);
            newNode.Next = top;
            top = newNode;
        }

        /// <summary>
        /// Remove and return the top item from the stack
        /// </summary>
        /// <returns>The top item from the stack by removing it completely</returns>
        /// <exception cref="Exception"></exception> Throw an exception if the stack is empty
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("The stack is empty.");
            }

            T data = top.Data;
            top = top.Next;

            return data;
        }

        /// <summary>
        /// Return the top item from the stack without removing it
        /// </summary>
        /// <returns>The data from the top of the stack</returns>
        /// <exception cref="Exception"></exception> Throw an exception if the stack is empty
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("The stack is empty.");
            }

            return top.Data;
        }

        public GenericLinkedListStack()
        {
            // Start with a null top 
            this.top = null;
        }
    }
}
