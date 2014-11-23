using System;
using System.Linq;

namespace Decorator
{
    //concrete decorator
    class CreamDecorator : BakeryDecorator
    {
        public CreamDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.name = "Cream";
            this.price = 1.0;
        }
    }
}
