using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange
{
    public class DataArtifactInputModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = String.Empty;

        public string? ImageURL { get; set; } = String.Empty;

        public string RawAlienText { get; set; } = String.Empty;

        public string TranslatedText { get; set; } = String.Empty;

        [Required(ErrorMessage = "Source is required")]
        public string Source { get; set; } = String.Empty;

        [Required(ErrorMessage = "Data Artifact Type Id is required")]
        [Range(1, 3)]
        public int DataArtifactTypeID { get; set; } = 0;

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public string EncryptionKey { get; set; } = String.Empty;

        public string? VideoURL { get; set; } = String.Empty;


    }
}
