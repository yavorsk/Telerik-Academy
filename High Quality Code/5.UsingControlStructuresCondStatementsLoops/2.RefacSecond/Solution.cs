using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.RefacSecond
{
    class Potato
    {

    }

    class Solution
    {
        static void main() 
        {
            Potato potato = new Potato();
            //... 
            if (potato != null) 
            {
               bool isRotten = Potato.IsRotten;
               bool hasBeenPeeled = Potato.IsPeeled;

               if(!potato.IsRotten && potato.HasBeenPeeled)
	            Cook(potato);
            }

            //...
            bool isInRangeX = (MIN_X <= x && x <= MAX_X);
            bool isInRangeY = (MIN_Y <= y && y <= MAX_Y);
            bool cellIsAllowed = true;
        
            if (isInRangeX && isInRangeY && cellIsAllowed)
            {
               VisitCell();
            }
        }
    }
}
