using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using _253501_Stepanov_Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace SerializerLib
{
    public class Serializer: ISerializer
    {
        public IEnumerable<Car> DeSerializeByLINQ(string fileName)
        {
            XDocument doc = XDocument.Load(fileName);
            var cars = (from car in doc.Descendants("Car")
                    select new Car
                    {
                        Model = car.Element("Model").Value,
                        Year = int.Parse(car.Element("Year").Value),
                        engine = new Engine
                        {
                            Power = int.Parse(car.Element("Engine").Element("Power").Value),
                            Works = bool.Parse(car.Element("Engine").Element("Works").Value),
                            FuelType = car.Element("Engine").Element("FuelType").Value
                        }
                    }).ToList();
            return cars;
        }
        public IEnumerable<Car> DeSerializeXML(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
            List<Car> cars = null;
            using (StreamReader r = new StreamReader(fileName))
            {
                cars = (List<Car>)serializer.Deserialize(r);
            }
            return cars;
        }
        public IEnumerable<Car> DeSerializeJSON(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                var cars = JsonConvert.DeserializeObject<List<Car>>(json);
                return cars;
            }
        }
        public void SerializeByLINQ(IEnumerable<Car> Cars, string fileName)
        {
            XDocument doc = new XDocument(new XElement("Cars",
           from car in Cars
           select new XElement("Car",
               new XElement("Model", car.Model),
               new XElement("Year", car.Year),
               new XElement("Engine",
                   new XElement("Power", car.engine.Power),
                   new XElement("Works", car.engine.Works),
                   new XElement("FuelType", car.engine.FuelType)
               )
           )
         ));
            doc.Save(fileName);
        }
        public void SerializeXML(IEnumerable<Car> Cars, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Car>));
            using (TextWriter textWriter = new StreamWriter(fileName))
            {
                xmlSerializer.Serialize(textWriter, Cars);
            }
        }
        public void SerializeJSON(IEnumerable<Car> Cars, string fileName)
        {

            string json = JsonConvert.SerializeObject(Cars, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
    }
}
    