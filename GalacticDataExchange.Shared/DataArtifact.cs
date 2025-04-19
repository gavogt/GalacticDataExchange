using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public class DataArtifact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; init; } = Guid.NewGuid();

        // Common Properties
        public string Name { get; init; }
        public string? ImageURL { get; init; }
        public string RawAlienText { get; init; }
        public string TranslatedText { get; set; }
        public DateTime TimeStamp { get; init; }
        public string Source { get; init; }
        public string EncryptionKey { get; init; }
        public string? VideoURL { get; set; }

        // Foreign Key
        public int DataArtifactTypeID { get; init; }
        public Guid UserID { get; init; }

        // Ef Navigation Properties
        public DataArtifactType? DataArtifactType { get; set; }
        public User? User { get; set; }
        public ICollection<DataArtifactLike>? Likes { get; set; } = new List<DataArtifactLike>();


        // Ctor
        public DataArtifact()
        {

        }

        public DataArtifact(string name, int dataArtifactTypeID, string? imageURL, string rawAlienText, string translatedText, string source, string encryptionKey, DateTime timestamp, string? videoURL, Guid userID)
        {
            Name = name;
            DataArtifactTypeID = dataArtifactTypeID;
            ImageURL = imageURL;
            RawAlienText = rawAlienText;
            TranslatedText = translatedText;
            Source = source;
            EncryptionKey = encryptionKey;
            TimeStamp = timestamp;
            VideoURL = videoURL;
            UserID = userID;

        }
    }
}
