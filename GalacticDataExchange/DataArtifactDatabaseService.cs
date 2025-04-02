using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange
{
    internal class DataArtifactDatabaseService
    {
        private readonly DataDBContext _context;

        public DataArtifactDatabaseService(DataDBContext context)
        {
            _context = context;
        }

        public async Task<DataArtifact> InsertDataAsync(DataArtifact dataArtifact)
        {
            _context.DataArtifacts.Add(dataArtifact);
            await _context.SaveChangesAsync();
            return dataArtifact;
        }
    }
}
