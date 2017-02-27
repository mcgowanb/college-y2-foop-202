using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_1
{
    class Car : Vehicle
    {
        public CarBodyType CarType { get; set; }

        /// <summary>
        /// default ctor calls the parent CTOR with the ojbec type
        /// </summary>
        public Car() : base (VehicleType.Car)
        {

        }

        /// <summary>
        /// ctor take arguments, calls the parent CTOR with the object type
        /// </summary>

        public Car(String make, String  model, int Price, int year, String colour, int mileage, CarBodyType carType) : base (VehicleType.Car)
        {
            this.Make = make;
            this.Model = model;
            this.Price = Price;
            this.Year = year;
            this.Colour = colour;
            this.Mileage = mileage;
            this.CarType = CarType;
        }


        /// <summary>
        /// Implementation of abstract method to geneate custom information for this object
        /// when writing to a file
        /// </summary>
        /// <returns></returns>
        public override string LineDataForFile()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
          this.Type,
          this.Make,
          this.Model,
          this.Price,
          this.Year,
          this.Colour,
          this.Mileage,
          this.Description,
          this.Image,
          this.CarType
          );
        }


        /// <summary>
        /// Overrides the default behaviour for the generic CreateFromFile method
        /// to allow more information to be added to the object when reading from a file
        /// </summary>
        /// <returns></returns>
        public override Vehicle CreateFromFile(String[] elems)
        {
            base.CreateFromFile(elems);
            this.CarType = GetCarTypeType(elems[9]);
            return this;
        }

        public CarBodyType GetCarTypeType(String t)
        {
            CarBodyType ct;
            Enum.TryParse(t.ToString(), out ct);
            return ct;
        }
    }

}
