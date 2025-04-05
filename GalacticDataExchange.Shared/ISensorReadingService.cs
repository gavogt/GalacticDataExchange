using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public interface ISensorReadingService
    {
        public Task InsertSensorReadingAsync(SensorReading sensorReading);

        public Task<List<SensorReading>> GetSensorReadingsAsync();
    }
}
