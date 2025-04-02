using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange
{
    internal class DataArtifactInputModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "Image URL is required")]
        public string ImageURL { get; set; } = String.Empty;

        [Required(ErrorMessage = "Raw Alien Text is required")]
        public string RawAlienText { get; set; } = String.Empty;

        [Required(ErrorMessage = "Translated Text is required")]
        public string TranslatedText { get; set; } = String.Empty;

        [Required(ErrorMessage = "Source is required")]
        public string Source { get; set; } = String.Empty;

        [Required(ErrorMessage = "Data Artifact Type ID is required")]
        [Range(1, int.MaxValue)]
        public int DataArtifactTypeID { get; set; } = 0;

        
    }
}
