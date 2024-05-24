using _253501_Stepanov_Lab1.Collections;
using _253501_Stepanov_Lab1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class cashregister : ICustomCashregister
    {

        public event EventHandler<MyEventArgs> TariffsChanged;
        public event EventHandler PassengersListChanged;
        public event EventHandler<MyEventArgs> ByTicket;


        MyCustomCollection<passanger<int>> baseofpassangers;
        MyCustomCollection<tarif<int>> tarifs;




        public cashregister()
        {
            baseofpassangers = new MyCustomCollection<passanger<int>>();
            tarifs = new MyCustomCollection<tarif<int>>();
        }

        public void addnewtarif(tarif<int> newtarif)
        {
            tarifs.Add(newtarif);
            OnTariffsChanged
            (new MyEventArgs($"Добавлен новый тариф: {newtarif.getname()} | {newtarif.getprice()}"));                                                                                                                      
        }
        public void addnewpassanger(passanger<int> newpassanger)
        {
            baseofpassangers.Add(newpassanger);
            OnPassengersListChanged
            (new MyEventArgs($"Добавлен новый пассажир: {newpassanger.getfio()}"));
            OnByTicket(new MyEventArgs($"Пассажир {newpassanger.getfio()} купил билет."));
        }
        public void showtarifs()
        {
            for (int i = 0; i < tarifs.Count; ++i)
            {
                Console.WriteLine
                ($"{i + 1}) Название направления: {tarifs[i].getname()} | Цена: {tarifs[i].getprice()}");
            }
        }
        public tarif<int> GetTarifByNumber(int number)
        {
            return tarifs[number];
        }


        
        public passanger<int> findpassenger(string fio)
        {   
            foreach(passanger<int> findpassenger in baseofpassangers)
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
            foreach (passanger<int> findpassenger in baseofpassangers)
            { 
                if (findpassenger.findlocationinpassenger(newlocation) == true)
                {
                    Console.WriteLine(findpassenger.getfio());
                    flag237894 = true;
                }
            }
            return flag237894;
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
