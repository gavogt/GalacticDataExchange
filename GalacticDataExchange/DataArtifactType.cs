using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange
{
    internal class DataArtifactType
    {
        private Guid ID = Guid.NewGuid();
        private string _Name { get; init; }
        private string _Description { get; init; }

    }
}
