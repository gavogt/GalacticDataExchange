using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public class DataArtifactDatabaseService
    {
        private readonly DataDBContext _context;

        public DataArtifactDatabaseService(DataDBContext context)
        {
            _context = context;
        }

        public async Task InsertDataArtifactAsync(DataArtifact dataArtifact)
        {
            try
            {
                _context.DataArtifacts.Add(dataArtifact);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting data artifact", ex);
            }
        }
    }
}
