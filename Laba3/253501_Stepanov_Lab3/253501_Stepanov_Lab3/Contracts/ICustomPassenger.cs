using _253501_Stepanov_Lab1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab1.Contracts
{
    public interface ICustomPassenger<T1,T2>
    {
        void registerticket(T2 item);

        string getfio();
        T1 genericcash();
        bool findlocationinpassenger(string mylocation);
        T1 getmainsum();

    }
}
