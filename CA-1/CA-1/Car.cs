using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_1
{
    enum CarBodyType { Convertible, HatchBack, Coupe, Estate, MPV, Saloon, Unlisted}
    class Car : Vehicle
    {
        public CarBodyType CarType { get; set; }
        public Car() : base (VehicleType.Car)
        {

        }

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
