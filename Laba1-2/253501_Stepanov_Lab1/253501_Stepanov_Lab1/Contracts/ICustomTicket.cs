using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab1.Contracts
{
    internal interface ICustomTicket<T>
    {
        T getprice();
        string getlocation();
    }
}
