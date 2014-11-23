using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class AudiCarFactory: CarFactory
    {
        public override SportCar CreateSportsCar()
        {
            return new AudiSportCar();
        }

        public override FamilyCar CreateFamilyCar()
        {
            return new AudiFamilyCar();
        }
    }
}
