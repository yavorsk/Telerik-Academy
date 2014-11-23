using System;
using GSM;

// 7.Write a class GSMTest to test the GSM class:
// Create an array of few instances of the GSM class.
// Display the information about the GSMs in the array.
// Display the information about the static property IPhone4S.

class GSMTestt
{
    static void Main()
    {
        Battery siemensBattery = new Battery(BatteryType.LiIon, null, null);
        Display siemensDisplay = new Display(null, null, 2);
        Phone myFirst = new Phone("C35", "Siemens", null, "Jack Reacher", siemensBattery, siemensDisplay);

        Battery nokiaBattery = new Battery(BatteryType.NiMH, 200, 15);
        Display nokiaDIsplay = new Display(120, 120, 16);
        Phone mySecond = new Phone("2230", "Nokia", null, "John Silver", nokiaBattery, nokiaDIsplay);

        Phone[] phones = new Phone[] { myFirst, mySecond };

        foreach (var phone in phones)
        {
            Console.WriteLine(phone.ToString());
        }

        Console.WriteLine(Phone.IPhone5S.ToString());

        Console.WriteLine(Phone.IPhone5S.BatteryType.HoursTalk);
    }
}