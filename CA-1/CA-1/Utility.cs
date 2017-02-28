using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CA_1
{
    class Utility
    {
        /// <summary>
        /// Converts a String hex colour to a Colour object. If it fails, return black colour
        /// </summary>
        public static Color GetColourFromString(String s)
        {
            try
            {
                return (Color)ColorConverter.ConvertFromString(s);
            }
            catch (FormatException e)
            {
                return (Color)ColorConverter.ConvertFromString("#FF000000");
            }

        }
        /// <summary>
        /// Converts String to number, returns 0 if fails
        /// </summary>
        public static int ConvertStringToInteger(String s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch (FormatException fe)
            {
                return 0;
            }
        }


        /// <summary>
        /// Utility method for getting the current image directory
        /// </summary>
        /// <returns></returns>
        public static String GetImageDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            DirectoryInfo parent = Directory.GetParent(currentDir);
            DirectoryInfo gParent = parent.Parent;
            currentDir = gParent.FullName;
            return currentDir + "\\images\\";
        }

        /// <summary>
        /// gets the current project working directory
        /// </summary>
        /// <returns></returns>
        public static String GetWorkingDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            DirectoryInfo parent = Directory.GetParent(currentDir);
            DirectoryInfo gParent = parent.Parent;
            return gParent.FullName + "\\";
        }

        /// <summary>
        /// Converts String to Enum Type
        /// </summary>
        /// <returns></returns>
        public static VehicleType GetVehicleType(String t)
        {
            VehicleType vt;
            try
            {
                Enum.TryParse(t.ToString(), out vt);
            }
            catch (NullReferenceException e)
            {
                vt = VehicleType.Car;
            }
            return vt;
        }


        public static String TrimTweetForDevelopment(String s)
        {
            String msg = String.Format("TESTING - IGNORE THIS: {0}", s);
            if (msg.Length >= 140)
            {
                return msg.Substring(0, 140);

            }
            else return msg;
        }
    }
}
