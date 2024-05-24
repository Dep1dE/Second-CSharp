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

        cashregister<int, passanger<int,ticket<int>>> maincashregister = new cashregister<int, passanger<int, ticket<int>>>();
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
            Console.WriteLine("Введите 6, Получение списка названий всех тарифов, отсортированного по стоимости");
            Console.WriteLine("Введите 7, Получение общей стоимости всех купленных на вокзале билетов.");
            Console.WriteLine("Введите 8, Получение общей стоимости всех купленных пассажиром билетов в соответствии с действующими тарифами");
            Console.WriteLine("Введите 9, Получение имени пассажира, заплатившего максимальную сумму. Если таких пассажиров несколько, получить имя первого в списке");
            Console.WriteLine("Введите 10, Получение количества пассажиров, заплативших больше определеной суммы");
            Console.WriteLine("Введите 11, Получение пассажиром списка сумм, заплаченных по каждому направлению");
            Console.WriteLine("Введите 12, если хотите завершить работу");
            x = input();
            switch (x)
            {
                case 1:
                    Console.WriteLine("Введите название направления:");
                    string newnameoflocation = Console.ReadLine();
                    Console.WriteLine("Введите цену за эту поездку:");
                    int coast = input();
                    tarif<int> newtarif = new tarif<int>(coast, newnameoflocation);
                    maincashregister.addnewtarif(newtarif);
                    break;
                case 2:
                    Console.WriteLine("Введите фио пассажира");
                    string fio = Console.ReadLine();
                    passanger<int, ticket<int>> newpassanger = new passanger<int, ticket<int>>(fio);
                    Console.WriteLine("Зарегистрируйте билет:");
                    while (z == 0)
                    {
                        Console.WriteLine("Тарифы кассы:");
                        maincashregister.ShowTariffs();
                        Console.WriteLine("Выберите тариф из предложенных");
                        int NumberOfTarif = input();
                        tarif<int> ThisTarif = maincashregister.GetTarifByNumber(NumberOfTarif);
                        ticket<int> NewTicket = new ticket<int>(ThisTarif.getprice(), ThisTarif.getname());
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
                    Console.Clear();
                    Console.WriteLine("Введите фио пассажира");
                    string myfio = Console.ReadLine();
                    passanger<int,ticket<int>> mypassanger = maincashregister.findpassenger(myfio);
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
                    Console.Clear();
                    Console.WriteLine("Введите название направления");
                    string mylocation;
                    mylocation = Console.ReadLine();
                    if (maincashregister.findlocation(mylocation) == false)
                    {
                        Console.WriteLine("Ни у одного из пассажиров нету такого направления");
                    }

                    break;

                case 5:
                    Console.Clear();
                    journal.ShowEventLog();
                    break;

                case 6:
                    Console.Clear();
                    maincashregister.GetSortTarifs();
                    break;
                case 7:
                    Console.Clear();
                    maincashregister.TicketsSum();
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Введит фио пассажира:");
                    string findfio = Console.ReadLine();
                    maincashregister.GetSumTicketPerson(findfio);
                    break;
                case 9:
                    Console.Clear();
                    maincashregister.GetMaxPersonSum();
                    break;
                case 10:
                    Console.Clear();
                    Console.WriteLine("Введит минимальную сумму:");
                    int MinSum = input();
                    maincashregister.CountOfPassengersWhoBoughtMoreThan(MinSum);
                    break;
                case 11:
                    Console.Clear();
                    var list = maincashregister.ListOfTicketsBy();

                    foreach (var item in list)
                    {
                        Console.WriteLine(item.Key);

                        foreach (var ticket in item)
                        {
                            Console.WriteLine($"{ticket.getfio()} заплатил {ticket.getmainsum()}");
                        }
                    }
                    break;

                case 12:
                    return 0;
                default:
                    Console.WriteLine("Ошибка ввода");
                    break;
            }
        }

    }
}