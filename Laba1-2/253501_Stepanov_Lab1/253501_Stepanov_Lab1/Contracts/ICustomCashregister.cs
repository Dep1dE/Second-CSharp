using _253501_Stepanov_Lab1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab1.Contracts
{
    internal interface ICustomCashregister
    {
        void addnewpassanger(passanger<int> newpassanger);
        passanger<int> findpassenger(string fio);
        bool findlocation(string newlocation);


    }
}
