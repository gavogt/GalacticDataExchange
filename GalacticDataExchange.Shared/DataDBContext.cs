using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GalacticDataExchange.Shared
{
    public class DataDBContext : DbContext
    {
        public DbSet<DataArtifact> DataArtifacts { get; set; }
        public DbSet<DataArtifactType> DataArtifactTypes { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorReading> SensorReadings { get; set; }

        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sensor's Readings is mapped to SensorReading's Sensor
            // on SensorReading's SensorID
            modelBuilder.Entity<Sensor>()
                .HasMany(s => s.Readings)
                .WithOne(sr => sr.Sensor)
                .HasForeignKey(sr => sr.SensorID);

            // Sensor ID is generated on add
            modelBuilder.Entity<Sensor>()
                .Property(s => s.SensorID)
                .ValueGeneratedOnAdd();

            // DataArtifactType is mapped to DataArtifact's DataArtifactTypeID
            modelBuilder.Entity<DataArtifact>()
                .HasOne(d => d.DataArtifactType)
                .WithMany()
                .HasForeignKey(d => d.DataArtifactTypeID);

            // DataArtifactType ID is generated on add
            modelBuilder.Entity<DataArtifactType>()
                .Property(dat => dat.ID)
                .ValueGeneratedOnAdd();

            // Seed Data for Sensor
            modelBuilder.Entity<Sensor>().HasData(
                new Sensor { SensorID = 1, SensorType = "Temperature", Location = "Bridge" },
                new Sensor { SensorID = 2, SensorType = "Pressure", Location = "Engineering" },
                new Sensor { SensorID = 3, SensorType = "Radiation", Location = "Cargo Bay" }
            );

            // Seed Data for DataArtifactType
            modelBuilder.Entity<DataArtifactType>().HasData(
                new DataArtifactType { ID = 1, Name = "Holographic Memory Cube", Description = "A cube that stores data in a holographic matrix." },
                new DataArtifactType { ID = 2, Name = "Encrypted Sensor Log", Description = "A sensor log that has been encrypted." },
                new DataArtifactType { ID = 3, Name = "Digital Relic Image", Description = "An image of a relic that has been digitized." });

            base.OnModelCreating(modelBuilder);
        }

    }
}
