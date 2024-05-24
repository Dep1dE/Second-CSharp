// See https://aka.ms/new-console-template for more information
using _253501_Stepanov_Lab1.Entities;
using static System.Collections.Specialized.BitVector32;

internal class Program
{
    private static int Main(string[] args)
    {
        static int input()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        cashregister maincashregister = new cashregister();
        Journal journal = new Journal();

        maincashregister.TariffsChanged += journal.RegisterEvent;



        journal.SubscribeToCashregister(maincashregister);
        maincashregister.ByTicket += (sender, e) =>
        {
            string message = (e as MyEventArgs)?.Message;
            if (message != null)
            {
                Console.WriteLine($"[Программа] Событие: {message}");
            }   
        };

        for (; ; )
        {
            int x, k, z = 0;
            Console.WriteLine("Функции кассы:");
            Console.WriteLine("Введите 1, если хотите добавить тариф");
            Console.WriteLine("Введите 2, если хотите добавить пассажира");
            Console.WriteLine("Введите 3, если хотите рассчитать общую сумму по фио пассажира");
            Console.WriteLine("Введите 4, если хотите найти пассажиров купивших билет в одно направление");
            Console.WriteLine("Введите 5, если хотите увидеть журнал событий");
            Console.WriteLine("Введите 6, если хотите завершить работу");
            x = input();
            switch (x)
            {
                case 1:
                    Console.WriteLine("Введите название направления:");
                    string newnameoflocation = Console.ReadLine();
                    Console.WriteLine("Введите цену за эту поездку:");
                    int coast=input();
                    tarif<int> newtarif = new tarif<int>(coast,newnameoflocation);
                    maincashregister.addnewtarif(newtarif);
                    break;
                case 2:
                    Console.WriteLine("Введите фио пассажира");
                    string fio = Console.ReadLine();
                    passanger<int> newpassanger = new passanger<int>(fio);
                    Console.WriteLine("Зарегистрируйте билет:");
                    while (z == 0)
                    {
                        Console.WriteLine("Тарифы кассы:");
                        maincashregister.showtarifs();
                        Console.WriteLine("Выберите тариф из предложенных");
                        int NumberOfTarif=input()-1;
                        tarif<int> ThisTarif=maincashregister.GetTarifByNumber(NumberOfTarif);
                        ticket<int> NewTicket=new ticket<int>(ThisTarif.getprice(),ThisTarif.getname());
                        newpassanger.registerticket(NewTicket);
                        Console.WriteLine("Хотите добавить еще билет?:");
                        Console.WriteLine("1-Да");
                        Console.WriteLine("2-Нет");
                        k = input();
                        switch (k)
                        {
                            case 1:
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                z = 1;
                                break;
                            default:
                                Console.WriteLine("Ошибка ввода");
                                break;
                        }
                        
                    }
                    maincashregister.addnewpassanger(newpassanger);
                    break;
                case 3:
                    Console.WriteLine("Введите фио пассажира");
                    string myfio = Console.ReadLine();
                    passanger<int> mypassanger = maincashregister.findpassenger(myfio);
                    if (mypassanger != null)
                    {
                        int t = mypassanger.genericcash();
                        Console.WriteLine("Общая стоимость билетов этого пассажира: " + t);
                    }
                    else
                    {
                        Console.WriteLine("Пассажир не найден");
                    }
                    break;
                case 4:
                    Console.WriteLine("Введите название направления");
                    string mylocation;
                    mylocation=Console.ReadLine();
                   if(maincashregister.findlocation(mylocation) == false)
                    {
                        Console.WriteLine("Ни у одного из пассажиров нету такого направления");
                    }
                    
                    break;

                case 5:
                    journal.ShowEventLog();
                    break;

                case 6:
                    return 0;
                default:
                    Console.WriteLine("Ошибка ввода");
                    break;
            }
        }

    }
}