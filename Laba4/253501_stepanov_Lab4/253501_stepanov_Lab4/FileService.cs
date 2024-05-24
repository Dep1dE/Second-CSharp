using _253501_stepanov_Lab4.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253501_stepanov_Lab4
{
    public class FileService<T>:IFileService<T> where T : Computer
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                T comp;
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    try
                    {
                        string Name = reader.ReadString();
                        bool Foreign = reader.ReadBoolean();
                        int Price = reader.ReadInt32();
                        comp = Activator.CreateInstance(typeof(T), Name, Foreign, Price) as T;
                    }
                    catch (Exception ex) {
                        Console.Error.WriteLine(ex.Message);
                        continue;
                    }
                    yield return comp;
                }
            }
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    foreach (var computer in data)
                    {
                        writer.Write(computer.Name);
                        writer.Write(computer.Foreign);
                        writer.Write(computer.Price);
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
            }
        }
    }
}
