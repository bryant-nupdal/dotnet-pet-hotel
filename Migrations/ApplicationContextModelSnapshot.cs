﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using pet_hotel.Models;

namespace dotnet_bakery.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("pet_hotel.Pet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("breed")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("checkedInAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("color")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("petOwnerid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("petOwnerid");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("pet_hotel.PetOwner", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("emailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("PetOwner");
                });

            modelBuilder.Entity("pet_hotel.Pet", b =>
                {
                    b.HasOne("pet_hotel.PetOwner", null)
                        .WithMany("pets")
                        .HasForeignKey("petOwnerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("pet_hotel.PetOwner", b =>
                {
                    b.Navigation("pets");
                });
#pragma warning restore 612, 618
        }
    }
}
