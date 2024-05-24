using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading
{
    public class IntegralCalculator
    {
        static Semaphore sem = new Semaphore(3, 3);
        private static Mutex mutex = new Mutex(); // Создаем мьютекс
        public event EventHandler<CalculationCompletedEventArgs> CalculationCompleted;
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
        public void CalculateIntegral()
        {
            sem.WaitOne();
            double h = 0.00000001;
            double sum = 0.0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int lastProgress = -1;

            //mutex.WaitOne();
            Console.WriteLine();
            try
            {

                for (int i = 0; i < 100000000; i++)
                {
                    load();
                    double x_i = i * h;
                    sum += Math.Sin(x_i);

                    int progress = (int)((i / 100000000.0) * 100);
                    if (progress != lastProgress)
                    {
                        OnProgressChanged(new ProgressChangedEventArgs(progress));
                        lastProgress = progress;
                        Console.Write($"\rПоток {Thread.CurrentThread.ManagedThreadId}: [{new string('=', progress / 2)}>{new string(' ', 50 - progress / 2 - 1)}] {progress}%");

                    }
                    if (progress == 99)
                    {
                        Console.WriteLine(); 
                        Console.WriteLine($"\rПоток {Thread.CurrentThread.ManagedThreadId}: Завершен с результатом: {h * sum}");
                        break;
                    }
                }
            }
            finally
            {
                CalculationCompletedEventArgs args = new CalculationCompletedEventArgs
                {
                    Result = h * sum,
                    ElapsedTime = stopwatch.Elapsed
                };
                OnCalculationCompleted(args);
                //mutex.ReleaseMutex();
                sem.Release();
            }

            stopwatch.Stop();
        }

        public void load()
        {
            for (int i = 0; i < 20; i++)  //Нужно потом изменить на 100000
            {
                int a = 2, b = 3;
                a = a * b;
            }
        }

        protected virtual void OnProgressChanged(ProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(this, e);
        }

        protected virtual void OnCalculationCompleted(CalculationCompletedEventArgs e)
        {
            CalculationCompleted?.Invoke(this, e);
        }
    }
}

public class CalculationCompletedEventArgs : EventArgs
{
    public double Result { get; set; }
    public TimeSpan ElapsedTime { get; set; }
}


public class ProgressChangedEventArgs : EventArgs
{
    public int Progress { get; }

    public ProgressChangedEventArgs(int progress)
    {
        Progress = progress;
    }
}