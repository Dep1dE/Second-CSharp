using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Lab1.Entities
{
    public class tarif<T>
    {
        T price;
        string name;
        public tarif(T price, string name)
        {
            this.price = price;
            this.name = name;
        }
        public T getprice() { return price; }
        public string getname() { return name; }

        public void setprice(T price) {  this.price = price; }
        public void setname(string name) { this.name = name; }



    }
}
