using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace _253501_Stepanov_Lab1.Entities
{
    internal class Journal {
        private List<string> eventLog = new List<string>();

        public void SubscribeToCashregister(cashregister<int, passanger<int, ticket<int>>> mycashregister)
        {
            //mycashregister.TariffsChanged += (sender, e) =>
            //{
            //    string message = (e as MyEventArgs)?.Message;
            //    if (message != null)
            //    {
            //        eventLog.Add(message);
            //        Console.WriteLine($"[Журнал] Событие: {message}");
            //    }
            //};
            //mycashregister.PassengersListChanged += (sender, e) =>
            //{
            //    string message = (e as MyEventArgs)?.Message;
            //    if (message != null)
            //    {
            //        eventLog.Add(message);
            //        Console.WriteLine($"[Журнал] Событие: {message}");
            //    }
            //};
        }

        public void RegisterEvent(object sender, MyEventArgs e)
        {
            eventLog.Add($"[Журнал] Событие: {e.Message}");
        }

        public void ShowEventLog()
        {
            Console.WriteLine("[Журнал] Зарегистрированные события:");
            foreach (var logEntry in eventLog)
            {
                Console.WriteLine(logEntry);
            }
        }


    }
}
