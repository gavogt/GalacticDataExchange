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

        private string _ArtifactType { get; init; }

        private string _ImageURL { get; init; }

        private string _RawAlienText { get; init; }

        private string _TranslatedText { get; set; }

        private DateTime _TimeStamp { get; init; }

        private string _SourceLanguage { get; init; }

    }
}
