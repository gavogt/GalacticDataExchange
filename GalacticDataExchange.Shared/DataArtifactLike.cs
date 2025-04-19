using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(DataArtifact))]
        public Guid DataArtifactID { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }

        // EF Navigation
        public DataArtifact? DataArtifact { get; set; }
        public User? User { get; set; }


    }
}
