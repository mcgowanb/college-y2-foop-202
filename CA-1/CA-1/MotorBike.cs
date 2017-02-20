using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_1
{
    class MotorBike : Vehicle
    {

        public MotorBike() : base(VehicleType.Motorbike)
        {

        }

        public MotorBike(String make, String model, int Price, int year, String colour) : base (VehicleType.Motorbike)
        {
            this.Make = make;
            this.Model = model;
            this.Price = Price;
            this.Year = year;
            this.Colour = colour;
        }
    }
}
