using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange
{
    internal class DataArtifact
    {
        [Key]
        private Guid ID = Guid.NewGuid();

        // Common Properties
        private string _Name { get; init; }

        private string _ImageURL { get; init; }

        private string _RawAlienText { get; init; }

        private string _TranslatedText { get; set; }

        private DateTime _TimeStamp { get; init; } = DateTime.Now;

        private string _Source { get; init; }

        // Foreign Key
        private int _DataArtifactTypeID { get; init; }

        // Ef Navigation
        DataArtifactType? DataArtifactType { get; set; }

        public DataArtifact()
        {
            
        }

        public DataArtifact(string name, int dataArtifactTypeID, string imageURL, string rawAlienText, string translatedText, string source)
        {
            _Name = name;
            _DataArtifactTypeID = dataArtifactTypeID;
            _ImageURL = imageURL;
            _RawAlienText = rawAlienText;
            _TranslatedText = translatedText;
            _Source = source;

        }

    }
}
