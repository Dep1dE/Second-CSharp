using _253501_Stepanov_Lab1.Collections;
using _253501_Stepanov_Lab1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab1.Entities
{
    public class passanger<T1> : ICustomPassenger<T1> where T1 : INumber<T1>
    {
        public int sum;
        private string fio;
        MyCustomCollection<ticket<T1>> tickets;
        public passanger(string fio)
        {
            this.fio = fio;
            tickets = new MyCustomCollection<ticket<T1>>();
        }
        public void registerticket(ticket<T1> newticket)
        {
            tickets.Add(newticket);
        }
        public string getfio()
        {
            return fio;
        }


        public T1 genericcash()
        {
            T1 sum = default(T1);
            foreach (ticket<T1> ticket in tickets)
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
            foreach (ticket<T1> ticket in tickets)
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
