using System;

class Solution
{
    public void PrintStatistics(double[] data)
    {
        double maxNumber = GetMax(data);
        Console.WriteLine(maxNumber);

        double minNumber = GetMin(data);
        Console.WriteLine(minNumber);

        double averageValue = GetAverage(data);
        Console.WriteLine(averageValue);
    }

    private double GetMax(double[] data)
    {
        double maxNumber = data[0];

        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] > maxNumber)
            {
                maxNumber = data[i];
            }
        }

        return maxNumber;
    }

    private double GetMin(double[] data)
    {
        double minNumber = data[0];

        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] < minNumber)
            {
                minNumber = data[i];
            }
        }

        return minNumber;
    }

    private double GetAverage(double[] data)
    {
        double sum = 0;

        for (int i = 0; i < data.Length; i++)
        {
            sum += data[i];
        }

        double average = sum / data.Length;

        return average;
    }
}