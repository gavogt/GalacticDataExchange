﻿// <auto-generated />
using System;
using GalacticDataExchange.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GalacticDataExchange.Shared.Migrations
{
    [DbContext(typeof(DataDBContext))]
    [Migration("20250404224317_SensorTable4")]
    partial class SensorTable4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GalacticDataExchange.Shared.DataArtifact", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DataArtifactTypeID")
                        .HasColumnType("int");

                    b.Property<string>("EncryptionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RawAlienText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("TranslatedText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DataArtifactTypeID");

                    b.ToTable("DataArtifacts");
                });

            modelBuilder.Entity("GalacticDataExchange.Shared.DataArtifactType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DataArtifactTypes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "A cube that stores data in a holographic matrix.",
                            Name = "Holographic Memory Cube"
                        },
                        new
                        {
                            ID = 2,
                            Description = "A sensor log that has been encrypted.",
                            Name = "Encrypted Sensor Log"
                        },
                        new
                        {
                            ID = 3,
                            Description = "An image of a relic that has been digitized.",
                            Name = "Digital Relic Image"
                        });
                });

            modelBuilder.Entity("GalacticDataExchange.Shared.Sensor", b =>
                {
                    b.Property<int>("SensorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SensorID"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SensorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SensorID");

                    b.ToTable("Sensors");

                    b.HasData(
                        new
                        {
                            SensorID = 1,
                            Location = "Bridge",
                            SensorType = "Temperature"
                        },
                        new
                        {
                            SensorID = 2,
                            Location = "Engineering",
                            SensorType = "Pressure"
                        },
                        new
                        {
                            SensorID = 3,
                            Location = "Cargo Bay",
                            SensorType = "Radiation"
                        });
                });

            modelBuilder.Entity("GalacticDataExchange.Shared.SensorReading", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SensorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("SensorID");

                    b.ToTable("SensorReadings");
                });

            modelBuilder.Entity("GalacticDataExchange.Shared.DataArtifact", b =>
                {
                    b.HasOne("GalacticDataExchange.Shared.DataArtifactType", "DataArtifactType")
                        .WithMany()
                        .HasForeignKey("DataArtifactTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataArtifactType");
                });

            modelBuilder.Entity("GalacticDataExchange.Shared.SensorReading", b =>
                {
                    b.HasOne("GalacticDataExchange.Shared.Sensor", "Sensor")
                        .WithMany("Readings")
                        .HasForeignKey("SensorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("GalacticDataExchange.Shared.Sensor", b =>
                {
                    b.Navigation("Readings");
                });
#pragma warning restore 612, 618
        }
    }
}
