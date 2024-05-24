using _253501_Stepanov_Lab1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _253501_Stepanov_Lab1.Entities
{
    public class MyEventArgs : EventArgs
    {
        public string Message { get; }

        public MyEventArgs(string message)
        {
            Message = message;
        }
    }

    public class cashregister<T1,T2> : ICustomCashregister<T1, T2> where T1: INumber<T1> where T2: class,ICustomPassenger<int, ticket<T1>> 
    {

        public event EventHandler<MyEventArgs> TariffsChanged;
        public event EventHandler PassengersListChanged;
        public event EventHandler<MyEventArgs> ByTicket;


        List<T2> baseofpassangers;

        Dictionary<string, T1> tarifs;




        public cashregister()
        {
            baseofpassangers = new List<T2>();
            tarifs = new Dictionary<string, T1>();
        }

        public void addnewtarif(tarif<T1> newtarif)
        {
            tarifs.Add(newtarif.getname(), newtarif.getprice());
            OnTariffsChanged
            (new MyEventArgs($"Добавлен новый тариф: {newtarif.getname()} | {newtarif.getprice()}"));                                                                                                                      
        }
        public void addnewpassanger(T2 newpassanger)
        {
            baseofpassangers.Add(newpassanger);
            OnPassengersListChanged
            (new MyEventArgs($"Добавлен новый пассажир: {newpassanger.getfio()}"));
            OnByTicket(new MyEventArgs($"Пассажир {newpassanger.getfio()} купил билет."));
        }
        public void ShowTariffs()
        {
            int i = 1;
            foreach (var kvp in tarifs)
            {
                Console.WriteLine($"{i}) Название направления: {kvp.Key} | Цена: {kvp.Value}");
                i++;
            }
        }
        public tarif<T1> GetTarifByNumber(int number)
        {
            int i = 1;
            tarif<T1> newtarif=new tarif<T1>(default,"");
           
                foreach (var kvp in tarifs)
                { 
                    newtarif.setprice(kvp.Value);
                    newtarif.setname(kvp.Key);
                    if (i == number) { return newtarif; }
                    else { ++i; }
                }
            return null;
        }


        
        public T2 findpassenger(string fio) 
        {   
            foreach(T2 findpassenger in baseofpassangers)
            {
                        if (findpassenger.getfio() == fio)
                {
                    return findpassenger; 
                }
            }
            return null;
        }

        public bool findlocation(string newlocation)
        {
            bool flag237894 = false;
            foreach (T2 findpassenger in baseofpassangers)
            { 
                if (findpassenger.findlocationinpassenger(newlocation) == true)
                {
                    Console.WriteLine(findpassenger.getfio());
                    flag237894 = true;
                }
            }
            return flag237894;
        }

        public void GetSortTarifs()
        {
            var SortedTarifs = tarifs.OrderBy(t => t.Value);
            var TarifNames = SortedTarifs.Select(t => t.Key);

            foreach (var name in TarifNames)
            {
                Console.WriteLine(name);
            }
        }

        public void TicketsSum()
        {
            var Sum=baseofpassangers.Sum(t => t.getmainsum());
            Console.WriteLine($"Общая цена купленных билетов: {Sum}");
        }

        public void GetSumTicketPerson(string fio)
        {
            var Sum= (from p in baseofpassangers where p.getfio().StartsWith(fio) select p.getmainsum()).Sum();
            Console.WriteLine($"Общая стоимость купленных билетов пассажиром: {Sum}");

        }

        public void GetMaxPersonSum()
        {
            var SortedTarifs = baseofpassangers.OrderByDescending(t => t.getmainsum());
            var Fio = SortedTarifs.First().getfio();
            Console.WriteLine($"Пассажир заплативший максимальную сумму: {Fio}");

        }

        public void CountOfPassengersWhoBoughtMoreThan(int minSum)
        {
            var CountPassengers= baseofpassangers.Aggregate(0, (count, passenger) => passenger.getmainsum().CompareTo(minSum) > 0 ? count + 1 : count);
            Console.WriteLine($"Колличество пассажиров заплативших сумму большую чем {minSum}: {CountPassengers}");
        }

        public IEnumerable<IGrouping<string, T2>> ListOfTicketsBy()
        {
            var list = from item in baseofpassangers group item by item.getfio();

            return list;
        }
        protected virtual void OnTariffsChanged(MyEventArgs e)
        {
            TariffsChanged?.Invoke(this, e);
        }

        protected virtual void OnPassengersListChanged(MyEventArgs e)
        {
            PassengersListChanged?.Invoke(this, e);
        }

        protected virtual void OnByTicket(MyEventArgs e)
        {
            PassengersListChanged?.Invoke(this, e);
        }
    }
}
