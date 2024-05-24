using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab1.Contracts
{
    internal interface IGenericSubtraction<T>
    {
        T Subtract(T a, T b);
    }
}
