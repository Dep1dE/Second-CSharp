using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Domain
{
    [Serializable]
    public class Engine
    {
        public int Power { get; set; }
        public bool Works { get; set; }
        public string FuelType { get; set; }
    }
}
