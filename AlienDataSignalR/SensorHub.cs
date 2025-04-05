using Microsoft.AspNetCore.SignalR;
using GalacticDataExchange.Shared;

namespace AlienDataSignalR
{
    // SignalR hub that manges real-time sensor data
    public class SensorHub: Hub
    {
        
        private readonly ISensorReadingService? _sensorReadingService;

        // Constructor that takes a ISensorReadingService as a parameter
        public SensorHub(ISensorReadingService sensorReadingService)
        {
            _sensorReadingService = sensorReadingService;
        }

        // Send sensor reading to hub
        // Hub broadcasts the reading to all connected clients
        public async Task SendSensorReading(SensorReading reading)
        {
            if(reading == null)
            {
                throw new ArgumentNullException(nameof(reading), "Sensor reading cannot be null");
            }

            // Broadcast the sensor reading to all connected clients
            await Clients.All.SendAsync("ReceiveSensorReading", reading);

            if(_sensorReadingService == null)
            {
                throw new InvalidOperationException("SensorReadingService is not initialized");
            }   

            // Insert the sensor reading into the database
            await _sensorReadingService.InsertSensorReadingAsync(reading);
        }
    }
}
