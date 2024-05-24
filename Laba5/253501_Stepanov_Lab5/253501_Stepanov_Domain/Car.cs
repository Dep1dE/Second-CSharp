using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_Stepanov_Domain
{
    [Serializable]
    public class Car : IEquatable<Car>
    {

        public Engine engine { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Car() { }
        public Car(Engine _engine, string model, int year)
        {
            engine = _engine;
            Model = model;
            Year = year;
        }
        public bool Equals(Car other)
        {
            if (other == null)
                return false;

            return this.engine.Works == other.engine.Works && this.engine.FuelType == other.engine.FuelType && this.engine.Power == other.engine.Power && this.Model == other.Model && this.Year==other.Year;
        }
        public void StartEngine()
        {
            engine.Works = true;
        }
        public void StopEngine()
        {
            engine.Works = false;
        }
        public void ChangePower(int power)
        {
            engine.Power = power;
        }
        public void IndicateFuelType(string FuelType)
        {
            engine.FuelType = FuelType;
        }
    }
}
