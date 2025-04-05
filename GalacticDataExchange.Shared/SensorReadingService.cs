using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GalacticDataExchange.Shared
{
    public class SensorReadingService : ISensorReadingService
    {
        // DbContext for accessing the database
        private readonly DataDBContext _context;

        // Constructor that takes a DbContext as a parameter
        public SensorReadingService(DataDBContext context)
        {
            _context = context;
        }

        // Method to insert a new sensor reading into the database
        public async Task InsertSensorReadingAsync(SensorReading sensorReading)
        {
            _context.SensorReadings.Add(sensorReading);
            await _context.SaveChangesAsync();
        }

        // Method to retrieve all sensor readings from the database
        public async Task<List<SensorReading>> GetSensorReadingsAsync()
        {
            return await _context.SensorReadings.ToListAsync();
        }
    }
}
