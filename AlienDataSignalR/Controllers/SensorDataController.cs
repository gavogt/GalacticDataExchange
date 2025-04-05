using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GalacticDataExchange.Shared;
using System.Collections.Generic;

namespace AlienDataSignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        // endpoint that returns sensor data
        [HttpGet]
        public IEnumerable<Sensor> GetSensors()
        {
            // Simulate fetching sensor data from a database or other source
            return new List<Sensor>
            {
                new Sensor{ SensorID = 1, SensorType="Temperature", Location="Lab A"},
                new Sensor{ SensorID =2, SensorType="Pressure", Location="Lab B"},
            };
        }
    }
}
