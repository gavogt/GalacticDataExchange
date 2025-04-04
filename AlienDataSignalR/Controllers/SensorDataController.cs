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
        [HttpGet]
        public IEnumerable<Sensor> GetSensors()
        {
            return new List<Sensor>
            {
                new Sensor{ SensorType="Temperature", Location="Lab A"},
                new Sensor{ SensorType="Pressure", Location="Lab B"},
            };
        }
    }
}
