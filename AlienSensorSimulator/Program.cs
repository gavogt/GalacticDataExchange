using GalacticDataExchange;
using GalacticDataExchange.Shared;
using static System.Console;


internal class Program
{

    static async Task Main(string[] args)
    {
        Random rand = new Random();
        SensorClient sensorClient = new SensorClient();

        // Start the SignalR client
        await sensorClient.StartAsync();

        // Simulate a sensor reading
        var sensorReading = new SensorReading
        {
            SensorID = rand.Next(1, 1000),
            Value = 42.0,
            Unit = "Celsius",
        };

        // Send the sensor reading to the SignalR hub
        await sensorClient.SendSensorReadingAsync(sensorReading);

        WriteLine("Sensor reading sent.");

        WriteLine("Press any key to exit...");

        ReadKey();

    }
}