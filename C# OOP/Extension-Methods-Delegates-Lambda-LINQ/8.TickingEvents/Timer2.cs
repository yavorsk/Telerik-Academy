using System;
using System.Diagnostics;

// 8. * Read in MSDN about the keyword event in C# and how to publish events. 
// Re-implement the above using .NET events and following the best practices.
// used this: http://www.codeproject.com/Articles/11541/The-Simplest-C-Events-Example-Imaginable

public class Timer2
{
    public delegate void TicTac(Timer2 t, EventArgs e);
    public event TicTac Tick;
    public EventArgs e = null;
    public int t;

    public Timer2(int t)
    {
        this.t = t;
    }

    public void Start()
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();

        while (true)
        {
            if (timer.Elapsed.TotalSeconds % t == 0)
            {
                Tick(this, e);
            }
        }
    }
}

public class DoSmth
{
    static bool tic = true;

    public void Subscribe(Timer2 t)
    {
        t.Tick += new Timer2.TicTac(WriteTicks);
    }

    public void WriteTicks(Timer2 t, EventArgs e)
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

public class Timer2test
{
    static void Main()
    {
        Timer2 timer = new Timer2(3);
        DoSmth ticking = new DoSmth();
        ticking.Subscribe(timer);
        timer.Start();
    }
}
