using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalacticDataExchange;
using Microsoft.EntityFrameworkCore;

namespace GalacticDataExchange.Shared
{
    public class SensorService : ISensorService
    {
        private readonly DataDBContext _context;

        public SensorService(DataDBContext context)
        {
            _context = context;

        }

        public async Task<List<Sensor>> GetSensorsAsync()
        {
            return await _context.Sensors.ToListAsync();
        }
    }
}
