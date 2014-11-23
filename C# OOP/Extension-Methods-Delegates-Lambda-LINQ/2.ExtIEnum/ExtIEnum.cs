using System;
using System.Collections.Generic;
using System.Linq;

// 2. Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

static class ExtIEnum
{
    public static T Sum<T>(this IEnumerable<T> list)
    {
        T result = default(T);

        foreach (var item in list)
        {
            result += (dynamic)item;
        }

        return result;
    }

    public static T Product<T>(this IEnumerable<T> list)
    {
        T result = (dynamic)1;

        foreach (var item in list)
        {
            result *= (dynamic)item;
        }

        return result;
    }

    public static T Min<T>(this IEnumerable<T> list) where T : IComparable
    {
        dynamic result = long.MaxValue;

        foreach (var item in list)
        {
            if (item.CompareTo(result)<0)
            {
                result = item;
            }
        }

        return result;
    }

    public static T Max<T>(this IEnumerable<T> list) where T : IComparable
    {
        dynamic result = long.MinValue;

        foreach (var item in list)
        {
            if (item.CompareTo(result) > 0)
            {
                result = item;
            }
        }

        return result;
    }

    public static decimal Average<T>(this IEnumerable<T> list)
    {
        dynamic sum = default(T);
        double counter = 0;

        foreach (var item in list)
        {
            sum += item;
            counter++;
        }

        dynamic result = sum / counter;

        return (decimal)result;
    }
}
