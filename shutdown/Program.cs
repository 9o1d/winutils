using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    private static Timer timer;

    static void Main(string[] args)
    {
        var timerState = new TimerState { Counter = 0 };

        timer = new Timer(
            callback: new TimerCallback(TimerTask),
            state: timerState,
            dueTime: 300000,
            period: 300000);

        while (true)
        {
            Task.Delay(1000).Wait();
        }

        timer.Dispose();
        Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: done.");
    }

    private static void TimerTask(object timerState)
    {
        WebClient client = new WebClient();
        string s = client.DownloadString("https://example.com/status.php");
        int i = int.Parse(s);
        Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} : " + i);
        if (i == 1)
        {
            Process.Start("shutdown", "/g /f /t 5");
        }
    }

    class TimerState
    {
        public int Counter;
    }
}
