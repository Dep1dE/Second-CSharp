using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;

namespace _253501_stepanov_Lab4
{
    public class MyCustomComparer<T> : IComparer<T> where T : Computer
    {
        int IComparer<T>.Compare(T? x, T? y)
        {
            return string.Compare(x?.Name, y?.Name);
        }
    }
}
