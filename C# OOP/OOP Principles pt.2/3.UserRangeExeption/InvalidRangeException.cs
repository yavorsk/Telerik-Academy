using System;

class InvalidRangeException<T> : ApplicationException
{
    private T start;
    private T end;

    public T Start
    {
        get { return start; }
        private set { this.start = value; }
    }

    public T End
    {
        get { return end; }
        private set { this.end = value; }
    }

    public InvalidRangeException(string message, Exception causeEx, T start, T end)
        : base(message, causeEx)
    {
        this.Start = start;
        this.End = end;
    }

    public InvalidRangeException(string message, T start, T end) 
        : this(message, null, start, end)
    {
    }

    public InvalidRangeException(T start, T end)
        :this(null, start, end)
    {
    }
}
