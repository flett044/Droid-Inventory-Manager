﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    internal interface IMergeSort
    {
        public void Sort(IComparable[] collection, IComparable[] aux, int lo, int hi);
    }
}
