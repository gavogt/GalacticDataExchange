using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public class DataArtifactLike
    {
        [Key]
        public Guid Id { get; set; }

        // Common properties
        public DateTime TimeStamp { get; set; }

        // Foreign Key
        public Guid DataArtifactID { get; set; }
        public Guid UserID { get; set; }

        // EF Navigation
        public DataArtifact? DataArtifact { get; set; }
        public User? User { get; set; }


    }
}
