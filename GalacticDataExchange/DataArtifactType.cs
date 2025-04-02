using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange
{
    internal class DataArtifactType
    {
        [Key]
        private Guid ID = Guid.NewGuid();   

        // Common Properties
        private string _Name { get; init; } = String.Empty;
        private string _Description { get; init; } = String.Empty;

    }
}
