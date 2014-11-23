using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver pesho = new Driver("Pesho");

            CarFactory audi = new AudiCarFactory();
            CarFactory mercedes = new MercedesCarFactory();

            pesho.setCasualCar(audi);
            pesho.setGazarskaCar(mercedes);

            Console.WriteLine(pesho.ToString());
        }
    }
}
