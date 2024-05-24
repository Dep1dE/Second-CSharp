using _253501_Stepanov_Lab1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab1.Contracts
{
    internal interface ICustomCashregister<T1, T2>
    {
        void addnewpassanger(T2 newpassanger);
        T2 findpassenger(string fio);
        bool findlocation(string newlocation);
        void GetSortTarifs();
        void TicketsSum();
        void GetSumTicketPerson(string fio);
        void CountOfPassengersWhoBoughtMoreThan(int minSum);
        IEnumerable<IGrouping<string, T2>> ListOfTicketsBy();
    }
}
