using Microsoft.AspNetCore.SignalR;
using GalacticDataExchange.Shared;

namespace AlienDataSignalR
{
    public class SensorHub: Hub
    {
        public async Task SendSensorReading(SensorReading reading)
        {
            // Send the sensor reading to all connected clients
            await Clients.All.SendAsync("ReceiveSensorReading", reading);
        }
    }
}
