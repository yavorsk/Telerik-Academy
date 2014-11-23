using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    //abstract decorator
    public abstract class BakeryDecorator : BakeryComponent
    {
        BakeryComponent baseComponent = null;

        protected string name = "Undefined Decorator";
        protected double price = 0.0;

        protected BakeryDecorator(BakeryComponent baseComponent)
        {
            this.baseComponent = baseComponent;
        }
        public override string GetName()    
        {
            return string.Format("{0}, {1}", this.baseComponent.GetName(), this.name);
        }

        public override double GetPrice()       
        {
            return price + this.baseComponent.GetPrice();
        }
    }
}
