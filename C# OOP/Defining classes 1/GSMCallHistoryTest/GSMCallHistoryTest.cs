using System;
using GSM;

class GSMCallHistoryTest
{
   // 11. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
   // Create an instance of the GSM class.
   // Add few calls.
   // Display the information about the calls.
   // Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
   // Remove the longest call from the history and calculate the total price again.
   // Finally clear the call history and print it.

    static void Main()
    {
        Phone myPhone = new Phone("galaxyS", "samsung");

        myPhone.AddCalls(new Call(DateTime.Now, 35958588446, TimeSpan.FromSeconds(120)));
        myPhone.AddCalls(new Call(DateTime.UtcNow, 44887156321, TimeSpan.FromMinutes(3)));
        myPhone.AddCalls(new Call(DateTime.Now, 45641321486, TimeSpan.FromHours(0.5)));

        foreach (var heldCall in myPhone.CallHistory)
        {
            Console.WriteLine("Time of call: {0}", heldCall.TimeOfCall);
            Console.WriteLine("Dialed number: {0}", heldCall.DialedNumber);
            Console.WriteLine("Duration of the call in seconds: {0}", heldCall.DurationOfCall.TotalSeconds);
            Console.WriteLine();
        }

        Console.WriteLine(myPhone.CalculatePriceForHeldCalls(0.37M));

        TimeSpan longestCall = TimeSpan.MinValue;
        int longestCallIndex = 0;

        for (int i = 0; i < myPhone.CallHistory.Count; i++)
        {
            if (longestCall<myPhone.CallHistory[i].DurationOfCall)
            {
                longestCall = myPhone.CallHistory[i].DurationOfCall;
                longestCallIndex = i;
            }
        }

        myPhone.RemoveCall(longestCallIndex);

        Console.WriteLine(myPhone.CalculatePriceForHeldCalls(0.37M));

        myPhone.ClearCallHistory();
        Console.WriteLine(myPhone.CallHistory.Count);
    }
}
