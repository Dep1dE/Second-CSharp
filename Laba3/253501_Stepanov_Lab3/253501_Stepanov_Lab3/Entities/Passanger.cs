using _253501_Stepanov_Lab1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab1.Entities
{
    public class passanger<T1,T2> : ICustomPassenger<T1,T2> where T1 : INumber<T1> where T2 :ICustomTicket<T1>
    {
        public T1 MainSum;
        private string fio;
        List<T2> tickets;
        public passanger(string fio)
        {
            this.fio = fio;
            tickets = new List<T2>();
            MainSum  = default(T1);
        }
        public void registerticket(T2 newticket)
        {
            tickets.Add(newticket);
            MainSum += newticket.getprice();
        }
        public string getfio()
        {
            return fio;
        }

        public T1 getmainsum()
        {
            return MainSum;
        }


        public T1 genericcash()
        {
            T1 sum = default(T1);
            foreach (T2 ticket in tickets)
            {
                sum = GenericMath<T1>(sum, ticket.getprice());
            }
            return sum;
        }

        private static T GenericMath<T>(T A, T B) where T : INumber<T>
        {
            return A + B;
        }

        public bool findlocationinpassenger(string mylocation)
        {
            foreach (T2 ticket in tickets)
            {
                if (ticket.getlocation() == mylocation)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
