using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _253501_stepanov_Lab4
{
    public class Computer
    {
        public int Price { get; set; }
        public bool Foreign { get; set; }
        public string Name { get; set; }

        public Computer(string Name, bool Foreign, int Price) { 
            this.Name = Name;
            this.Foreign = Foreign;
            this.Price = Price;
        }

    }
}
