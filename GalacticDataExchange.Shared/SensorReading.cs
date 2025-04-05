using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public class SensorReading
    {
        [Key]
        public Guid ID { get; init; } = Guid.NewGuid();

        // Common Properties
        public DateTime TimeStamp { get; init; } = DateTime.Now;
        public double Value { get; set; }
        public string Unit { get; set; } = String.Empty;

        // Foreign Key
        public int SensorID { get; set; } = 0;

        // EF Navigation
        [ForeignKey(nameof(SensorID))]
        public Sensor? Sensor { get; set; }

        public SensorReading(double value, string unit, int sensorID)
        {
            Value = value;
            Unit = unit;
            SensorID = sensorID;

        }
    }
}
