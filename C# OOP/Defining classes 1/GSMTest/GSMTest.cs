using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSM;

namespace GSMTest
{
    class GSMTest
    {
        static void Main()
        {
            Battery siemensBattery = new Battery(BatteryType.LiIon, null, null);
            Display siemensDisplay = new Display(null, null, 2);
            GSM.GSM myFirst = new GSM.GSM("C35", "Siemens", null, "Jack Reacher", siemensBattery, siemensDisplay);

            Battery nokiaBattery = new Battery(BatteryType.NiMH, 200, 15);
            Display nokiaDIsplay = new Display(120, 120, 16);
            GSM.GSM mySecond = new GSM.GSM("2230", "Nokia", null, "John Silver", nokiaBattery, nokiaDIsplay);

            GSM.GSM[] phones = new GSM.GSM[] { myFirst, mySecond };

            foreach (var phone in phones)
            {
                Console.WriteLine(phone.ToString());
            }

           // Console.WriteLine(GSM.GSM.IPhone5S.ToString());
        }
    }
}
