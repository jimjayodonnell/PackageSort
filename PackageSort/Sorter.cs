namespace PackageSort
{
    public static class Sorter
    {
        private const double maxDimension = 150;
        private const double maxVolume = 1000000;
        private const double maxWeight = 20;
        private const string rejected = "REJECTED";
        private const string special = "SPECIAL";
        private const string standard = "STANDARD";

        /// <summary>
        /// Sorts package into Rejected, Special, or Standard
        /// </summary>
        /// <param name="width">width in cm</param>
        /// <param name="height">height in cm</param>
        /// <param name="length">length in cm</param>
        /// <param name="mass">mass in kg</param>
        /// <returns>string Rejected, Special, or Standard</returns>
        public static string sort(double width, double height, double length, double mass)
        {
            //Rejects package if any parameters are negative or zero
            if (width <= 0 || height <= 0 || length <= 0 || mass <= 0)
                return rejected;

            var bulky = IsBulky(width, height, length);
            var heavy = IsHeavy(mass);

            //Rejects if both bulky and heavu
            if (bulky && heavy)
                return rejected;
            
            //Special if either bulky or heavy
            if (bulky || heavy)
                return special;

            //Else standard
            return standard;
        }

        /// <summary>
        /// Checks if dimensions are less than 150cm
        /// Or if volume is less than 1,000,000cm^3
        /// </summary>
        /// <param name="width">width in cm</param>
        /// <param name="height">height in cm</param>
        /// <param name="length">length in cm</param>
        /// <returns>returns true if dimensions are too large</returns>
        private static bool IsBulky(double width, double height, double length)
        {
            //Bulky if any individual dimension is larger than max
            if (width >= maxDimension
                || height >= maxDimension
                || length >= maxDimension)
                return true;

            var volume = width * height * length;

            if (volume >= maxVolume)
                return true;

            return false;
        }

        /// <summary>
        /// Checks if package is less than max weight
        /// </summary>
        /// <param name="mass">mass in kg</param>
        /// <returns>true if package is greater than or equal to max weight</returns>
        private static bool IsHeavy(double mass)
        {
            if (mass >= maxWeight)
                return true;

            return false;
        }
    }
}
