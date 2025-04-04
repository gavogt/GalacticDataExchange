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
            // DataArtifactType is mapped to DataArtifact's DataArtifactTypeID
            modelBuilder.Entity<DataArtifact>()
                .HasOne(d => d.DataArtifactType)
                .WithMany()
                .HasForeignKey(d => d.DataArtifactTypeID);

            // DataArtifactType ID is generated on add
            modelBuilder.Entity<DataArtifactType>()
                .Property(dat => dat.ID)
                .ValueGeneratedOnAdd();

            // Seed Data for DataArtifactType
            modelBuilder.Entity<DataArtifactType>().HasData(
                new DataArtifactType { ID = 1, Name = "Holographic Memory Cube", Description = "A cube that stores data in a holographic matrix." },
                new DataArtifactType { ID = 2, Name = "Encrypted Sensor Log", Description = "A sensor log that has been encrypted." },
                new DataArtifactType { ID = 3, Name = "Digital Relic Image", Description = "An image of a relic that has been digitized." });

            base.OnModelCreating(modelBuilder);
        }

    }
}
