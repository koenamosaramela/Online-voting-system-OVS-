﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OVS.Database;

#nullable disable

namespace OVS.Migrations
{
    [DbContext(typeof(SQLiteDBContext))]
    partial class SQLiteDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.33");

            modelBuilder.Entity("OVS.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OVS.Database.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ElectionType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocalParty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NationalParty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProvincialParty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}