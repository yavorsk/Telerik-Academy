using System;
using System.Linq;

namespace Decorator
{
    // concrete component
    class CakeBase : BakeryComponent
    {
        public string Name {get; set;}
        public double Price {get; set;}

        public override string GetName()
        {
            return this.Name;
        }

        public override double GetPrice()
        {
            return this.Price;
        }
    }
}
