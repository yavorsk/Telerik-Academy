using System;
using System.Linq;

namespace Decorator
{
    //concrete decorator
    class CherryDecorator : BakeryDecorator
    {
        public CherryDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.name = "Cherry";
            this.price = 2.0;
        }
    }
}
