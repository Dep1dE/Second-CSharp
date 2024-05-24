using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Domain
{
    public interface ISerializer
    {
        IEnumerable<Car> DeSerializeByLINQ(string fileName);
        IEnumerable<Car> DeSerializeXML(string fileName);
        IEnumerable<Car> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Car> Cars, string fileName);
        void SerializeXML(IEnumerable<Car> Cars, string fileName);
        void SerializeJSON(IEnumerable<Car> Cars, string fileName);
    }
}
