using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab6
{
    public class Computer
    {
        public string Name { set; get; }
        public int Coast { set; get; }
        public bool Foreign { set; get; }
        public Computer() { 
            Name =""; Coast = 0; Foreign = false;
        } 
        public Computer(string name, int coast, bool foreign) { 
            Name = name; Coast = coast; Foreign = foreign;
        }
    }
}
