using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_1
{
    class Car : Vehicle
    {
        public Car() : base (VehicleType.Car)
        {

        }

        public Car(String make, String  model, int Price, int year, String colour, int mileage) : base (VehicleType.Car)
        {
            this.Make = make;
            this.Model = model;
            this.Price = Price;
            this.Year = year;
            this.Colour = colour;
            this.Mileage = mileage;
        }
    }
}
