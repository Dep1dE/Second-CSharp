using _253501_Stepanov_Lab6;
using System.Reflection;
class Program
{
    static void Main(string[] args)
    {

        var Computers = new List<Computer>
    {
    new Computer
    {
        Name = "Comp1",
        Coast = 2000,
        Foreign=false
    },
    new Computer
    {
        Name = "Comp2",
        Coast = 3000,
        Foreign=true
    },
    new Computer
    {
        Name = "Comp3",
        Coast = 2500,
        Foreign=true
    },
    new Computer
    {
        Name = "Comp4",
        Coast = 1550,
        Foreign=false
    },
    new Computer
    {
        Name = "Comp5",
        Coast = 3200,
        Foreign=true
    }
        };

        Assembly assembly = Assembly.LoadFrom("D:\\WorkTable\\BSUIR\\Программирование_сем2\\Laba6\\253501_Stepanov_Lab6\\FileService\\bin\\Debug\\net8.0\\FileService.dll");
        Type fileServiceType = assembly.GetType("FileService.FileService");
        object fileServiceInstance = Activator.CreateInstance(fileServiceType);
        MethodInfo saveDataMethod = fileServiceType.GetMethod("SaveData");
        saveDataMethod.Invoke(fileServiceInstance, new object[] { Computers, "comp.json" });
        MethodInfo readFileMethod = fileServiceType.GetMethod("ReadFile");
        IEnumerable<Computer> result = (IEnumerable<Computer>)readFileMethod.Invoke(fileServiceInstance, new object[] { "comp.json" });

        foreach (var computer in result)
        {
            Console.WriteLine(computer.Name);
            Console.WriteLine(computer.Coast);
            Console.WriteLine(computer.Foreign);
            Console.WriteLine("_________________");
        }
    }
}