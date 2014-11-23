using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let us create a Simple Cake Base first
            CakeBase cBase = new CakeBase();

            // Lets add cream to the cake
            CreamDecorator creamCake = new CreamDecorator(cBase);

            // Let now add a Cherry on it
            CherryDecorator cherryCake = new CherryDecorator(creamCake);

            // Lets now add Scent to it
            ArtificialScentDecorator scentedCake = new ArtificialScentDecorator(cherryCake);

            // Finally add a Name card on the cake
            NameCardDecorator nameCardOnCake = new NameCardDecorator(scentedCake);

            // Lets now create a simple Pastry
            PastryBase pastry = new PastryBase();

            // Lets just add cream and cherry only on the pastry 
            CreamDecorator creamPastry = new CreamDecorator(pastry);
            CherryDecorator cherryPastry = new CherryDecorator(creamPastry);
        }
    }
}
