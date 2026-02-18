using System;
using System.Collections.Generic;
using System.Text;

namespace PackageSort
{
    public static class Sorter
    {
        private const double maxDimension = 150;
        private const double maxVolume = 1000000;
        private const double maxWeight = 20;

        public static string sort(double width, double height, double length, double mass)
        {
            if (width <= 0 || height <= 0 || length <= 0 || mass <= 0)
                return "REJECTED";

            var bulky = IsBulky(width, height, length);
            var heavy = IsHeavy(mass);

            if (bulky && heavy)
                return "REJECTED";
            
            if (bulky || heavy)
                return "SPECIAL";

            return "STANDARD";
        }

        private static bool IsBulky(double width, double height, double length)
        {
            if (width >= maxDimension
                || height >= maxDimension
                || length >= maxDimension)
                return true;

            var volume = width * height * length;

            if (volume >= maxVolume)
                return true;

            return false;
        }

        private static bool IsHeavy(double mass)
        {
            if (mass >= maxWeight)
                return true;

            return false;
        }
    }
}
