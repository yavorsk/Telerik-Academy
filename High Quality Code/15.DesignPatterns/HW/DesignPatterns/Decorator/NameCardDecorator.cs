using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    // concrete decorator
    class NameCardDecorator : BakeryDecorator
    {
        private int discountRate = 5;

        public NameCardDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.name = "Name Card";
            this.price = 4.0;
        }

        public override string GetName()
        {
            return base.GetName() +
                string.Format("\n(Please Collect your discount card for {0}%)",
                discountRate);
        }
    }
}
