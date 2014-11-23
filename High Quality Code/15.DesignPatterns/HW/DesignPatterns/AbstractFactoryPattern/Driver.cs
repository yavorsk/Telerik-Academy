using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class Driver
    {
        FamilyCar CasualCar { get; set; }
        SportCar GazarskaCar { get; set; }
        string Name { get; set; }

        public Driver(string name) 
        {
            this.Name = name;
        }

        public void setCasualCar(CarFactory factory)
        {
            this.CasualCar = factory.CreateFamilyCar();
        }

        public void setGazarskaCar(CarFactory factory)
        {
            this.GazarskaCar = factory.CreateSportsCar();
        }

        public override string ToString()
        {
            string result = string.Format("Driver " + this.Name + " has a " + this.CasualCar.GetType().Name
                                            + " and a " + this.GazarskaCar.GetType().Name);
            return result;
        }
    }
}
