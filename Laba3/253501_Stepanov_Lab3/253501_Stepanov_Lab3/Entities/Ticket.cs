using _253501_Stepanov_Lab1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab1.Entities
{
    public class ticket<T> : ICustomTicket<T>
    {
        private T price;
        private string location;
        public ticket(T price, string location)
        {
            this.price = price;
            this.location = location;
        }
        public T getprice()
        {
            return price;
        }

        public string getlocation()
        {
            return location;
        }

    }
}
