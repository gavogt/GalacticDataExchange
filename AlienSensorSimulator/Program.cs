using GalacticDataExchange;
using GalacticDataExchange.Shared;
using System;
using static System.Console;


internal class Program
{

    static async Task Main(string[] args)
    {
        Random rand = new Random();
        SensorClient sensorClient = new SensorClient();

        // Start the SignalR client
        await sensorClient.StartAsync();

        int readingCount = rand.Next(1, 10);

        for (int i = 0; i < readingCount; i++)
        {
            // Array of sensor types
            string[] sensorTypes = { "Temperature", "Pressure", "Humidity", "Light", "Vibration", "Motion" };

            // Randomly select a sensor type
            string randomType = sensorTypes[rand.Next(sensorTypes.Length)];

            // Randomly select a sensor ID
            int sensorID = rand.Next(1, sensorTypes.Length);

            // Randomly generate a sensor value
            double randomValue = rand.NextDouble() * 100;

            // Get a random unit for the selected sensor type
            string randomUnit = AlienUnitDictionary.GetRandomUnit(randomType);

            // Simulate a sensor reading
            var sensorReading = new SensorReading(randomValue, randomUnit, sensorID);

            // Send the sensor reading to the SignalR hub
            await sensorClient.SendSensorReadingAsync(sensorReading);

        }

        WriteLine("Sensor reading sent.");

        WriteLine("Press any key to exit...");

        ReadKey();

    }
}