using Microsoft.AspNetCore.SignalR.Client;
using GalacticDataExchange.Shared;
using System;

namespace GalacticDataExchange
{

    public class SensorClient
    {
        // SignalR Hub connection
        private HubConnection _hubConnection;

        // Set up SignalR connection and register a handler
        public SensorClient()
        {
            // Build the connection to the SignalR hub at specified URL
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7183/sensorhub")
                .Build();

            // Handler for ReceiveSensorReading event
            // This will be called when a sensor reading is received from the hub
            _hubConnection.On<SensorReading>("ReceiveSensorReading", (sensorReading) =>
            {
                Console.WriteLine($"Received sensor reading: ID:{sensorReading.ID} VALUE:{sensorReading.Value} UNIT{sensorReading.Unit}");
            });

        }

        public async Task StartAsync()
        {
            try
            {
                // Start the connection to the SignalR hub
                await _hubConnection.StartAsync();
                Console.WriteLine("Sensor client started.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting sensor client: {ex.Message}");
            }

        }

        // Invoke SendSensorReading method on hub sending sensorReading object
        public async Task SendSensorReadingAsync(SensorReading sensorReading)
        {
            try
            {
                await _hubConnection.SendAsync("SendSensorReading", sensorReading);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending sensor reading: {ex.Message}");
            }

        }
    }
}