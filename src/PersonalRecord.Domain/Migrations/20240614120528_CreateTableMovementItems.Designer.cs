﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalRecord.Domain.Models.Entities;

#nullable disable

namespace PersonalRecord.Domain.Migrations
{
    [DbContext(typeof(PersonalRecordContext))]
    [Migration("20240614120528_CreateTableMovementItems")]
    partial class CreateTableMovementItems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("PersonalRecord.Domain.Models.Entities.Movement", b =>
                {
                    b.Property<Guid>("MovementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MovementID");

                    b.ToTable("MovementItems");
                });
#pragma warning restore 612, 618
        }
    }
}