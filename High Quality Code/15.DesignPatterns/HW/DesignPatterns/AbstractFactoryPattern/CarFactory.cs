using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public abstract class CarFactory
    {
        public abstract SportCar CreateSportsCar();
        public abstract FamilyCar CreateFamilyCar();
    }
}                    