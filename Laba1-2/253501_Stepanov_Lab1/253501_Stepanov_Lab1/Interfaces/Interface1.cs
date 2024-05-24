using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab1.Interfaces
{
    internal interface ICustomCollection<T> : IEnumerable<T>
    {
        T this[int index] { get; set; }
        int Count { get; }

        void Reset();
        void Next();
        T Current();
        void Add(T item);
        void Remove(T item);
        T RemoveCurrent();
    }

}

