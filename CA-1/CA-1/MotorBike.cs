using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_1
{
    class MotorBike : Vehicle
    {
        /// <summary>
        /// default CTOR calling the parent with the default type
        /// </summary>
        public MotorBike() : base(VehicleType.Motorbike)
        {

        }
        /// <summary>
        /// n-args CTOR calling the parent CTOR with the vehicle type
        /// </summary>
        public MotorBike(String make, String model, int Price, int year, String colour, int mileage) : base(VehicleType.Motorbike)
        {
            this.Make = make;
            this.Model = model;
            this.Price = Price;
            this.Year = year;
            this.Colour = colour;
            this.Mileage = mileage;
        }


        /// <summary>
        /// Implementation of abstract method
        /// </summary>
        /// <returns></returns>
        public override string LineDataForFile()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
          this.Type,
          this.Make,
          this.Model,
          this.Price,
          this.Year,
          this.Colour,
          this.Mileage,
          this.Description,
          this.Image
          );
        }
    }
}
