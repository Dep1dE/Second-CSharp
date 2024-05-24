using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_stepanov_Lab4
{
    public class GenerationFile
    {
        public string DirectoryPath { get; set; }

        public GenerationFile(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }

        public void CreateMainFolder(string DirectoryName) {
            Directory.CreateDirectory(DirectoryName);
        }
        public void CreateRandomFile()
        {
            var randomFileName = @"D:\WorkTable\BSUIR\Программирование_сем2\Laba4\Stepanov_Lab4\" + Path.GetRandomFileName();
            using (FileStream fs = File.Create(randomFileName)) { }
            string[] Extensions = { ".txt", ".rtf", ".dat", ".inf" };
            File.Move(randomFileName, randomFileName.Replace(Path.GetExtension(randomFileName), Extensions[new Random().Next(0, Extensions.Length)]));
        }
        public void CreateTenRandomFiles() { 
            for (int i = 0; i < 10; i++)
            {
                CreateRandomFile();
            }
        }
        public void ReadFolder(string DirectoryName)
        {
            string[] allfiles = Directory.GetFiles(DirectoryName);
            foreach (string filename in allfiles)
            {
                Console.WriteLine("Файл: "+Path.GetFileNameWithoutExtension(filename)+" имеет расширение "+ Path.GetExtension(filename));
            }
        }
    }
}
