using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange
{
    public class DataArtifact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; init; } = Guid.NewGuid();

        // Common Properties
        public string Name { get; init; }

        public string ImageURL { get; init; }

        public string RawAlienText { get; init; }

        public string TranslatedText { get; set; }

        public DateTime TimeStamp { get; init; } = DateTime.Now;

        public string Source { get; init; }

        // Foreign Key
        public int DataArtifactTypeID { get; init; }

        // Ef Navigation
        public DataArtifactType? DataArtifactType { get; set; }

        public DataArtifact()
        {
            
        }

        public DataArtifact(string name, int dataArtifactTypeID, string imageURL, string rawAlienText, string translatedText, string source)
        {
            Name = name;
            DataArtifactTypeID = dataArtifactTypeID;
            ImageURL = imageURL;
            RawAlienText = rawAlienText;
            TranslatedText = translatedText;
            Source = source;

        }

    }
}
