using System;
using System.Diagnostics;

// 7. Using delegates write a class Timer that has can execute certain method at each t seconds.

public delegate void TicTac();

class Timer
{
    static bool tic = true;

    public void Ticking(TicTac tickingDelegate, int seconds)
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();

        while (true)
        {
            if (timer.Elapsed.TotalSeconds % seconds == 0)
            {
                tickingDelegate();
            }
        }
    }

    public void WriteTicks()
    {
        if (tic)
        {
            Console.WriteLine("tic...");
        }
        else
        {
            Console.WriteLine("tac...");
        }
        tic = !tic;
    }
}

class test
{
    static void Main()
    {
        Timer t = new Timer();
        
        TicTac tickingClock = t.WriteTicks;
        int intervalInSeconds = 2;
        t.Ticking(tickingClock, intervalInSeconds);
    }
}