using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<DataArtifact>> GetDataArtifactAsync(int DataArtifactTypeID)
        {
            try
            {
                var dataArtifact = await _context.DataArtifacts
                    .Where(a => a.DataArtifactTypeID == DataArtifactTypeID)
                    .ToListAsync();

                return dataArtifact;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting data artifact", ex);
            }
        }
    }
}
