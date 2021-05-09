using System;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace TechDoseDSA
{
    public class MinHeap : Heap
    {
        protected override bool IsMax => false;
    }
}
