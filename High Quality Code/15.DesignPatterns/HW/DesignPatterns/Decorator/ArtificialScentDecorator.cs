using System;
using System.Linq;

namespace Decorator
{
    //concrete decorator
    class ArtificialScentDecorator: BakeryDecorator
    {
        public ArtificialScentDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.name = "Artificial Scent";
            this.price = 3.0;
        }
    }
}
