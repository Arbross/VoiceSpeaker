using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Converter
    {
        public static double KilogramsToGrams(double kilograms)
        {
            return kilograms * 1000;
        }

        public static double GramsToKilograms(double grams)
        {
            return grams / 1000;
        }

        public static double TonnesToKilograms(double tonnes)
        {
            return tonnes * 1000;
        }

        public static double KilogramsToTonnes(double kg)
        {
            return kg / 1000;
        }

        public static double KilogramsToPounds(double kg)
        {
            return kg * 2.20462262185;
        }

        public static double PoundsToKilograms(double po)
        {
            return po / 2.20462262185;
        }

        public static double MeterToKilometer(double meter)
        {
            return meter / 1000;
        }

        public static double KilometerToMeter(double km)
        {
            return km * 1000;
        }

        public static double MillimetersToMeter(double mm)
        {
            return mm * 1000;
        }

        public static double MeterToMillimeters(double m)
        {
            return m / 1000;
        }

        public static double CentimetersToMeter(double cm)
        {
            return cm / 100;
        }

        public static double MeterToCentimeters(double m)
        {
            return m * 100;
        }

        public static double MillimetersToCentimeters(double mm)
        {
            return mm / 10;
        }

        public static double CentimetersToMillimeters(double cm)
        {
            return cm * 10;
        }

        public static double MillilitersToLiter(double ml)
        {
            return ml / 1000;
        }

        public static double LiterToMilliliters(double l)
        {
            return l * 1000;
        }

        public static double DecimetreToCentimeters(double dm)
        {
            return dm * 10;
        }

        public static double CentimetersToDecimetre(double cm)
        {
            return cm / 10;
        }

        public static double DecimetreToMilliliters(double dm)
        {
            return dm * 100;
        }

        public static double MillilitersToDecimetreT(double mm)
        {
            return mm / 100;
        }
    }
}
