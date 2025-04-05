using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public static class AlienUnitDictionary
    {
        // Dictionary to map sensor types to their respective units
        public static readonly Dictionary<string, string[]> SensorTypeUnits = new Dictionary<string, string[]>()
        {
            { "Temperature", new[] { "Zytherion", "Cryos", "PyroFlux" } },
            { "Pressure",    new[] { "Gravitas", "Xenobar", "Pressurion" } },
            { "Humidity",    new[] { "Moistarion", "Vaporae", "HydroMist" } },
            { "Light",       new[] { "Luminaris", "Photonix", "RadiantFlux" } },
            { "Vibration",   new[] { "Oscilloid", "QuiverX", "VibroWave" } },
            { "Motion",      new[] { "Kinetix", "Gravimove", "FluxMotion" } },
        };

        // A static random instance for generating random numbers
        private static readonly Random rand = new Random();

        // Method to get a random unit for a given sensor type
        public static string GetRandomUnit(string sensorType)
        {
            // Get array of units for the sensortype
            if (SensorTypeUnits.TryGetValue(sensorType, out var possibleUnits))
            {
                // Assign random unit length to Index
                int index = rand.Next(possibleUnits.Length);

                // Return the unit at the random index
                return possibleUnits[index];
            }
            else
            {
                return "UnknownUnits";
            }
        }
    }
}
