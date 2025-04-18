using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public class DataArtifactViewModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int DataArtifactTypeID { get; init; } 
        public string? ThumbnailURL { get; init; }
        public string TranslatedText { get; init; } = string.Empty;
        public int LikeCount { get; set; } 
    }
}
