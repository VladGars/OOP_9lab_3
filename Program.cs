using System;
using System.Threading;


public delegate void Action();


public class AlarmClock
{

    public event Action Alarm;

 
    public void Start(int seconds)
    {
        Console.WriteLine($"Будильник заведено на {seconds} секунд...");

        Thread.Sleep(seconds * 1000);


        if (Alarm != null)
        {
            Console.WriteLine("Дззззз! Час прокидатися!");
            Alarm();
        }
    }
}


public class TestMain
{

    public static void WakeUp()
    {
        Console.WriteLine("Реакція на подію: Треба вставати...");
    }

    public static void Main()
    {
        AlarmClock clk = new AlarmClock();

        clk.Alarm += new Action(WakeUp);


        clk.Alarm += () => Console.WriteLine("Реакція №2: Вимкнути будильник!");

        clk.Start(3);
    }
}
