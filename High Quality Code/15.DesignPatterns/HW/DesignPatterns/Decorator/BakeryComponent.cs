using System;
using System.Linq;

namespace Decorator
{
    //abstract base component
    public abstract class BakeryComponent
    {
        public abstract string GetName();
        public abstract double GetPrice();
    }
}
