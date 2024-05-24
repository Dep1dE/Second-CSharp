using _253501_Stepanov_Lab1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab1.Contracts
{
    internal interface ICustomPassenger<T1>
    {
        void registerticket(ticket<T1> item);

        string getfio();
        T1 genericcash();
        bool findlocationinpassenger(string mylocation);


    }
}
