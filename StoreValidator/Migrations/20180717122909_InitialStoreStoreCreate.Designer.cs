﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using StoreValidator.Data;
using StoreValidator.Models;
using System;

namespace StoreValidator.Migrations
{
    [DbContext(typeof(StoreValidatorDbContext))]
    [Migration("20180717122909_InitialStoreStoreCreate")]
    partial class InitialStoreStoreCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreValidator.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Desc")
                        .HasMaxLength(120);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("OpenDate");

                    b.Property<string>("PostCode");

                    b.Property<long>("StoreSize");

                    b.Property<int>("StoreType");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
