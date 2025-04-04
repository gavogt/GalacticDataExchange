using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    internal class SensorReading
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
        Sensor? Sensor { get; set; }
    }
}
