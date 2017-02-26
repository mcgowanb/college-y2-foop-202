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

        /// <summary>
        /// Creates line record for writing to file
        /// </summary>
        /// <returns></returns>
        public override string LineDataForFile()
        {
            String line = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
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
            return line;
        }
    }
}
