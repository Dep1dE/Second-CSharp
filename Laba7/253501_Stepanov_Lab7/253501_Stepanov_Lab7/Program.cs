using Threading;
using System.Threading;

class Program
{
    static void Main()
    {
        IntegralCalculator calculator1 = new IntegralCalculator();
        IntegralCalculator calculator2 = new IntegralCalculator();
        IntegralCalculator calculator3 = new IntegralCalculator();
        IntegralCalculator calculator4 = new IntegralCalculator();
        IntegralCalculator calculator5 = new IntegralCalculator();

        calculator1.CalculationCompleted += (sender, e) =>
        { 
            Console.WriteLine($"Время выполнения (Поток {Thread.CurrentThread.ManagedThreadId}): {e.ElapsedTime}");
        };

        calculator2.CalculationCompleted += (sender, e) =>
        {
            Console.WriteLine($"Время выполнения (Поток {Thread.CurrentThread.ManagedThreadId}): {e.ElapsedTime}");
        };

        calculator3.CalculationCompleted += (sender, e) =>
        {
            Console.WriteLine($"Время выполнения (Поток {Thread.CurrentThread.ManagedThreadId}): {e.ElapsedTime}");
        };

        calculator4.CalculationCompleted += (sender, e) =>
        {
            Console.WriteLine($"Время выполнения (Поток {Thread.CurrentThread.ManagedThreadId}): {e.ElapsedTime}");
        };

        calculator5.CalculationCompleted += (sender, e) =>
        {
            Console.WriteLine($"Время выполнения (Поток {Thread.CurrentThread.ManagedThreadId}): {e.ElapsedTime}");
        };

        calculator1.ProgressChanged += (sender, e) =>
        {
        };

        calculator2.ProgressChanged += (sender, e) =>
        {
        };

        calculator3.ProgressChanged += (sender, e) =>
        {
        };

        calculator4.ProgressChanged += (sender, e) =>
        {
        };

        calculator5.ProgressChanged += (sender, e) =>
        {
        };

        Thread calculationThread1 = new Thread(calculator1.CalculateIntegral);
        Thread calculationThread2 = new Thread(calculator2.CalculateIntegral);
        Thread calculationThread3 = new Thread(calculator3.CalculateIntegral);
        Thread calculationThread4 = new Thread(calculator4.CalculateIntegral);
        Thread calculationThread5 = new Thread(calculator5.CalculateIntegral);

        //calculationThread1.Priority = ThreadPriority.Highest; 
        //calculationThread2.Priority = ThreadPriority.Lowest;  

        calculationThread1.Start();
        calculationThread2.Start();
        calculationThread3.Start();
        calculationThread4.Start();
        calculationThread5.Start();

        calculationThread1.Join();
        calculationThread2.Join();
        calculationThread3.Join();
        calculationThread4.Join();
        calculationThread5.Join();

        Console.WriteLine("Главный поток завершен.");
    }
}