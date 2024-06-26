﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    internal interface IGenericLinkedListQueue<T>
    {
        void Enqueue(T item);

        T Dequeue();

        T Peek();

        bool IsEmpty();
    }
}
