using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class IronItem : Item
    {
        const int InitialIronItemValue = 3;

        public IronItem(string name, Location location = null)
            : base(name, IronItem.InitialIronItemValue, ItemType.Iron, location)
        {
        }
    }
}
