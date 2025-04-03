using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange
{
    public class DataArtifactType
    {
        [Key]
        public int ID { get; init; }

        // Common Properties
        public string Name { get; init; } = String.Empty;
        public string Description { get; init; } = String.Empty;

    }
}
