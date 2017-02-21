using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_1
{
    public enum VehicleType { Car, Van, Motorbike }
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

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", Make, Model, Type, Colour, Mileage);
        }

        public override bool Equals(object obj)
        {
            Vehicle tmp = obj as Vehicle;
            return this.Type.Equals(tmp.Type);
        }
    }


}
