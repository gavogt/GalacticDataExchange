using Microsoft.AspNetCore.SignalR;
using GalacticDataExchange.Shared;

namespace AlienDataSignalR
{
    // SignalR hub that manges real-time sensor data
    public class SensorHub: Hub
    {
        // Send sensor reading to hub
        // Hub broadcasts the reading to all connected clients
        public async Task SendSensorReading(SensorReading reading)
        {
            // Broadcast the sensor reading to all connected clients
            await Clients.All.SendAsync("ReceiveSensorReading", reading);
        }
    }
}
