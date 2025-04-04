using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    internal class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SensorID { get; set; }
        public string SensorType { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;

        public ICollection<SensorReading> Readings { get; set; } = new List<SensorReading>();
    }
}

