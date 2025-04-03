using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GalacticDataExchange
{
    public class DataDBContext : DbContext
    {
        public DbSet<DataArtifact> DataArtifacts { get; set; }
        public DbSet<DataArtifactType> DataArtifactTypes { get; set; }

        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataArtifact>()
                .HasOne(d => d.DataArtifactType)
                .WithMany()
                .HasForeignKey(d => d.DataArtifactTypeID);

            base.OnModelCreating(modelBuilder);
        }

    }
}
