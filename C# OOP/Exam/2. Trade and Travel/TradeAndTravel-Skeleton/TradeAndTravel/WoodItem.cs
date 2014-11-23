using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class WoodItem : Item
    {
        const int InitialWoodItemValue = 2;

        public WoodItem(string name, Location location = null)
            : base(name, WoodItem.InitialWoodItemValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.Value > 0)
            {
                this.Value --;
            }
        }
    }
}
