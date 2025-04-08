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
            // on SensorReading's Id
            modelBuilder.Entity<Sensor>()
                .HasMany(s => s.Readings)
                .WithOne(sr => sr.Sensor)
                .HasForeignKey(sr => sr.SensorID);

            // Sensor Id is generated on add
            modelBuilder.Entity<Sensor>()
                .Property(s => s.ID)
                .ValueGeneratedOnAdd();

            // DataArtifactType is mapped to DataArtifact's DataArtifactTypeID
            modelBuilder.Entity<DataArtifact>()
                .HasOne(d => d.DataArtifactType)
                .WithMany()
                .HasForeignKey(d => d.DataArtifactTypeID);

            // User is mapped to DataArtifact's User
            modelBuilder.Entity<DataArtifact>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserID);

            // DataArtifactType Id is generated on add
            modelBuilder.Entity<DataArtifactType>()
                .Property(dat => dat.ID)
                .ValueGeneratedOnAdd();

            // Seed Data for Sensor
            modelBuilder.Entity<Sensor>().HasData(
                new Sensor
                {
                    ID = 1,
                    Name = "Thermo-1",
                    Type = "Temperature",
                    Location = "Bridge of the Starfleet"
                },
                new Sensor
                {
                    ID = 2,
                    Name = "Baro-1",
                    Type = "Pressure",
                    Location = "Engineering Deck on the D'Vorik"
                },
                new Sensor
                {
                    ID = 3,
                    Name = "Hygro-1",
                    Type = "Humidity",
                    Location = "Cargo Bay of the Nebulon"
                },
                new Sensor
                {
                    ID = 4,
                    Name = "Lumina-1",
                    Type = "Light",
                    Location = "Observation Deck of the Helix"
                },
                new Sensor
                {
                    ID = 5,
                    Name = "Vibro-1",
                    Type = "Vibration",
                    Location = "Propulsion Chamber, Quasar Wing"
                },
                new Sensor
                {
                    ID = 6,
                    Name = "Motion-1",
                    Type = "Motion",
                    Location = "Navigational Bridge, Delta Sector"
                });


            // Seed Data for DataArtifactType
            modelBuilder.Entity<DataArtifactType>().HasData(
                new DataArtifactType { ID = 1, Name = "Holographic Memory Cube", Description = "A cube that stores data in a holographic matrix." },
                new DataArtifactType { ID = 2, Name = "Encrypted Sensor Log", Description = "A sensor log that has been encrypted." },
                new DataArtifactType { ID = 3, Name = "Digital Relic Image", Description = "An image of a relic that has been digitized." });

            base.OnModelCreating(modelBuilder);
        }

    }
}
