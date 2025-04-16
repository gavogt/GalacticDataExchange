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

        public async Task GetDataArtifactAsync(Guid id)
        {
            try
            {
                var dataArtifact = await _context.DataArtifacts.FindAsync(id);
                if (dataArtifact == null)
                {
                    throw new Exception("Data artifact not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting data artifact", ex);
            }
        }
    }
}
