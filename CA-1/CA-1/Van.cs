using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_1
{
 
    class Van : Vehicle
    {
        public WheelBase WheelBase { get; set; }
        public VanBodyType BodyType { get; set; }
        public Van() : base(VehicleType.Van)
        {

        }

        public Van(VanBodyType vt, WheelBase wb) : base(VehicleType.Van)
        {
            this.BodyType = vt;
            this.WheelBase = wb;
        }

        public Van(String make, String model, int Price, int year, String colour, int mileage) : base(VehicleType.Van)
        {
            this.Make = make;
            this.Model = model;
            this.Price = Price;
            this.Year = year;
            this.Colour = colour;
            this.Mileage = mileage;
        }

        public Van(String make, String model, int Price, int year, String colour, int mileage, VanBodyType vt, WheelBase wb) : base(VehicleType.Van)
        {
            this.Make = make;
            this.Model = model;
            this.Price = Price;
            this.Year = year;
            this.Colour = colour;
            this.Mileage = mileage;
            this.BodyType = vt;
            this.WheelBase = wb;
        }

        public override string ToString()
        {
            String line = String.Format("{0},{1},{2}",
                base.ToString(),
                this.WheelBase,
                this.BodyType
                );
            return line;
        }

        private WheelBase GetWheelBaseType(String t)
        {
            WheelBase wb;
            Enum.TryParse(t.ToString(), out wb);
            return wb;
        }

        public VanBodyType GetBodyType(String t)
        {
            VanBodyType bt;
            Enum.TryParse(t.ToString(), out bt);
            return bt;
        }

        public override Vehicle CreateFromFile(String[] elems)
        {
            base.CreateFromFile(elems);
            this.WheelBase = GetWheelBaseType(elems[9]);
            this.BodyType = GetBodyType(elems[10]);
            return this;
        }

        /// <summary>
        /// implementation of the abstract method
        /// </summary>
        /// <returns></returns>
        public override string LineDataForFile()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
         this.Type,
         this.Make,
         this.Model,
         this.Price,
         this.Year,
         this.Colour,
         this.Mileage,
         this.Description,
         this.Image,
         this.WheelBase,
         this.BodyType
         );
        }
    }
}
