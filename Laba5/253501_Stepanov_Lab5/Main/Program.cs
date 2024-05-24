using _253501_Stepanov_Domain;
using SerializerLib;
class Program
{
    static void Main(string[] args)
    {

    var CarsToSave = new List<Car>
    {
    new Car
    {
        Model = "Camry",
        Year = 2022,
        engine = new Engine
        {
            Power = 200,
            Works = true,
            FuelType = "Gasoline"
        }
    },
    new Car
    {
        Model = "Civic",
        Year = 2021,
        engine = new Engine
        {
            Power = 180,
            Works = true,
            FuelType = "Diesel"
        }
    },
    new Car
    {
        Model = "Mustang",
        Year = 2020,
        engine = new Engine
        {
            Power = 300,
            Works = true,
            FuelType = "Gasoline"
        }
    },
    new Car
    {
        Model = "Vesta",
        Year = 2000,
        engine = new Engine
        {
            Power = 100,
            Works = false,
            FuelType = "Gasoline"
        }
    },
    new Car
    {
        Model = "Skyline",
        Year = 2023,
        engine = new Engine
        {
            Power = 450,
            Works = true,
            FuelType = "Diesel"
        }
    }
    };

        
    Serializer serializer = new Serializer();
        serializer.SerializeByLINQ(CarsToSave, "cars1.xml");
        serializer.SerializeJSON(CarsToSave, "cars.json");
        serializer.SerializeXML(CarsToSave, "cars2.xml");
        var CarsToRead1 = serializer.DeSerializeXML("cars2.xml");
        var CarsToRead2 = serializer.DeSerializeByLINQ("cars1.xml");
        var CarsToRead3 = serializer.DeSerializeJSON("cars.json");
        //foreach (var Car in CarsToRead1)
        //{
        //    Console.WriteLine(Car.Model);
        //    Console.WriteLine(Car.Year);
        //    Console.WriteLine(Car.engine.FuelType);
        //    Console.WriteLine(Car.engine.Power);
        //    Console.WriteLine(Car.engine.Works);
        //    Console.WriteLine("_____________________");
        //}
        //foreach (var Car in CarsToRead2)
        //{
        //    Console.WriteLine(Car.Model);
        //    Console.WriteLine(Car.Year);
        //    Console.WriteLine(Car.engine.FuelType);
        //    Console.WriteLine(Car.engine.Power);
        //    Console.WriteLine(Car.engine.Works);
        //    Console.WriteLine("_____________________");
        //}
        //foreach (var Car in CarsToRead3)
        //{
        //    Console.WriteLine(Car.Model);
        //    Console.WriteLine(Car.Year);
        //    Console.WriteLine(Car.engine.FuelType);
        //    Console.WriteLine(Car.engine.Power);
        //    Console.WriteLine(Car.engine.Works);
        //    Console.WriteLine("_____________________");
        //}
        bool areEqual1 = CarsToSave.SequenceEqual(CarsToRead1);
        bool areEqual2 = CarsToSave.SequenceEqual(CarsToRead2);
        bool areEqual3 = CarsToSave.SequenceEqual(CarsToRead3);

        if (areEqual1) Console.WriteLine("SerializeByLINQ совпадает");
        if (areEqual2) Console.WriteLine("SerializeJSON совпадает");
        if (areEqual3) Console.WriteLine("SerializeXML совпадает");
    }
}