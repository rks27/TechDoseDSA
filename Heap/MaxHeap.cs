using System;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace TechDoseDSA
{
    public class MaxHeap : Heap
    {
        protected override bool IsMax => true;
    }
}
