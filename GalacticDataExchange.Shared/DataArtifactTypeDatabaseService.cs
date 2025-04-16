using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GalacticDataExchange.Shared
{
    public class DataArtifactTypeDatabaseService
    {
        private readonly DataDBContext _context;

        public DataArtifactTypeDatabaseService(DataDBContext context)
        {
            _context = context;
        }

        public async Task<List<DataArtifactType>> GetAllDataArtifactTypesAsync()
        {
            return await _context.DataArtifactTypes.ToListAsync();
        }
    }
}
