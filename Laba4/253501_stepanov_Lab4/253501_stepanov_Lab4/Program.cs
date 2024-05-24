using _253501_stepanov_Lab4;

class Program
{
    static void Main(string[] args)
    {
        GenerationFile MainGenerator=new GenerationFile(@"D:\WorkTable\BSUIR\Программирование_сем2\Laba4\Stepanov_Lab4");
        MainGenerator.CreateMainFolder(@"D:\WorkTable\BSUIR\Программирование_сем2\Laba4\Stepanov_Lab4");
        MainGenerator.CreateTenRandomFiles();
        MainGenerator.ReadFolder(@"D:\WorkTable\BSUIR\Программирование_сем2\Laba4\Stepanov_Lab4");
        List<Computer> computersToSave = new List<Computer>
        {
            new Computer("b", false, 1000),
            new Computer("c", true, 1500),
            new Computer("a", false, 800),
            new Computer("d", true, 2000),
            new Computer("f", false, 1700),
            new Computer("e", true, 600)
        };
        List<Computer> computersToRead = new List<Computer>();
        var fileService = new FileService<Computer>();
        MainGenerator.CreateMainFolder(@"D:\WorkTable\BSUIR\Программирование_сем2\Laba4\TestFolder");
        string fileName1 = @"D:\WorkTable\BSUIR\Программирование_сем2\Laba4\TestFolder\computers.dat";
        string fileName2 = @"D:\WorkTable\BSUIR\Программирование_сем2\Laba4\TestFolder\COMPUTERS.dat";
        Console.WriteLine("Исходные данные до записи в файл:");
        foreach (var computer in computersToSave)
        {
            Console.WriteLine($"Name: {computer.Name}, Foreign: {computer.Foreign}, Price: {computer.Price}");
        }
        fileService.SaveData(computersToSave, fileName1);
        Console.WriteLine("Данные успешно сохранены в файл.");
        File.Move(fileName1, fileName2);
        foreach (Computer i in fileService.ReadFile(fileName2))
        {
            computersToRead.Add(i);
        }

        Console.WriteLine("Прочитанные данные из файла:");
        foreach (var computer in computersToRead)
        {
            Console.WriteLine($"Name: {computer.Name}, Foreign: {computer.Foreign}, Price: {computer.Price}");
        }

        var sortedByNameComputers = computersToRead.OrderBy(computer => computer, new MyCustomComparer<Computer>());
        Console.WriteLine("Отсортированные данные по Name");
        foreach (var computer in sortedByNameComputers)
        {
            Console.WriteLine($"Name: {computer.Name}, Foreign: {computer.Foreign}, Price: {computer.Price}");
        }
        var sortedByPriceComputers = computersToRead.OrderBy(x => x.Price).ToList();
        Console.WriteLine("Отсортированные данные по Price");
        foreach (var computer in sortedByPriceComputers)
        {
            Console.WriteLine($"Name: {computer.Name}, Foreign: {computer.Foreign}, Price: {computer.Price}");
        }
    }
}