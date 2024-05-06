using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    internal interface IGenericLinkedListStack<T>
    {
        bool IsEmpty();

        void Push(T item);

        T Pop();

        T Peek();
    }
}
