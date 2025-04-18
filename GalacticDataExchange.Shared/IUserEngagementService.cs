using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    internal interface IUserEngagementService
    {
        Task<int> LikedAsync(Guid userID, Guid dataArtifactID);
        Task<int> UnlikedAsync(Guid userID, Guid dataArtifactID);
        Task<int> GetLikedCountAsync(Guid dataArtifactID);
        Task<bool> UserLikedAsync(Guid userID, Guid dataArtifactID);

    }
}
