using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_1
{
    public enum VehicleType { Car, Van, Motorbike }
    enum VanBodyType { CombiVan, Dropside, PanelVan, Pickup, Tipper, Unlisted }
    enum WheelBase { Short, Medium, Long, Unlisted }
    enum CarBodyType { Convertible, HatchBack, Coupe, Estate, MPV, Saloon, Unlisted }

    abstract class Vehicle
    {
        public String Make { get; set; }
        public String Model { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public String Colour { get; set; }
        public int Mileage { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        //public String Type { get; set; }
        public VehicleType Type { get; set; }


        public Vehicle(VehicleType type)
        {
            Type = type;
        }

        public String IconPath
        {
            get
            {
                return String.Format("/images/{0}.png", Type.ToString().ToLower());
            }
        }

        public override string ToString()
        {
           return String.Format("{0} for sale, Make: {1} Model: {2} Price: {3} Year: {4} Colour: {5} Description: {6}",
           this.Type,
           this.Make,
           this.Model,
           this.Price,
           this.Year,
           this.Colour,
           this.Description
           );
        }

        /// <summary>
        /// Could have done this, and have also implemented in ToString, but I have implemented the 
        /// abstract method to show that I know how to use it.
        /// </summary>
        /// <returns></returns>
        public abstract String LineDataForFile();


        public virtual Vehicle CreateFromFile(String[] elems)
        {
            this.Make = elems[1];
            this.Model = elems[2];
            this.Price = Utility.ConvertStringToInteger(elems[3]);
            this.Year = Utility.ConvertStringToInteger(elems[4]);
            this.Colour = elems[5];
            this.Mileage = Utility.ConvertStringToInteger(elems[6]);
            this.Description = elems[7];
            this.Image = elems[8];

            return this;
        }
    }


}
