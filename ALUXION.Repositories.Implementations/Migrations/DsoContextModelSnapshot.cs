﻿// <auto-generated />
using System;
using ALUXION.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ALUXION.Repositories.Implementations.Migrations
{
    [DbContext(typeof(ALUXIONContext))]
    partial class ALUXIONContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ALUXION.Domain.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Amenity");
                });

            modelBuilder.Entity("ALUXION.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("DisabledAccess")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ALUXION.Domain.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<decimal>("Cap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CovidId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StadiumId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StadiumId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ALUXION.Domain.Genesis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GdId")
                        .HasColumnType("int");

                    b.Property<bool>("Sold")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Genesis");
                });

            modelBuilder.Entity("ALUXION.Domain.GenesisPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Batch")
                        .HasColumnType("int");

                    b.Property<int>("Cap")
                        .HasColumnType("int");

                    b.Property<int>("MaxPerBatch")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GenesisPrices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Batch = 1,
                            Cap = 100,
                            MaxPerBatch = 3,
                            Price = 300m,
                            Quantity = 0,
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            Batch = 2,
                            Cap = 250,
                            MaxPerBatch = 5,
                            Price = 600m,
                            Quantity = 0,
                            Status = 2
                        },
                        new
                        {
                            Id = 3,
                            Batch = 3,
                            Cap = 450,
                            MaxPerBatch = 7,
                            Price = 999m,
                            Quantity = 0,
                            Status = 2
                        });
                });

            modelBuilder.Entity("ALUXION.Domain.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CanceledAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CanceledReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientSecret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Confirm")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentIntentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ALUXION.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleType = 0
                        },
                        new
                        {
                            Id = 2,
                            RoleType = 1
                        });
                });

            modelBuilder.Entity("ALUXION.Domain.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Booked")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Resale")
                        .HasColumnType("bit");

                    b.Property<string>("Row")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EventId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("ALUXION.Domain.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("ALUXION.Domain.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Taxes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Percentage = 5m,
                            Token = "GenesisDrop"
                        });
                });

            modelBuilder.Entity("ALUXION.Domain.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromId")
                        .HasColumnType("int");

                    b.Property<int>("GenesisId")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("ToId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("GenesisId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ToId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("ALUXION.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HasGenesisDrop")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAvalable")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "",
                            FirstName = "ALUXION",
                            IsActive = false,
                            IsAvalable = false,
                            LastName = "ALUXION",
                            Password = "",
                            Provider = "Google"
                        });
                });

            modelBuilder.Entity("ALUXION.Domain.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("ALUXION.Domain.Amenity", b =>
                {
                    b.HasOne("ALUXION.Domain.Category", null)
                        .WithMany("Amenities")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("ALUXION.Domain.Event", b =>
                {
                    b.HasOne("ALUXION.Domain.Stadium", null)
                        .WithMany("Events")
                        .HasForeignKey("StadiumId");
                });

            modelBuilder.Entity("ALUXION.Domain.Seat", b =>
                {
                    b.HasOne("ALUXION.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ALUXION.Domain.Event", null)
                        .WithMany("Seats")
                        .HasForeignKey("EventId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ALUXION.Domain.Transfer", b =>
                {
                    b.HasOne("ALUXION.Domain.User", "From")
                        .WithMany()
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ALUXION.Domain.Genesis", "Genesis")
                        .WithMany()
                        .HasForeignKey("GenesisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ALUXION.Domain.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.HasOne("ALUXION.Domain.User", "To")
                        .WithMany()
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("Genesis");

                    b.Navigation("Payment");

                    b.Navigation("To");
                });

            modelBuilder.Entity("ALUXION.Domain.User", b =>
                {
                    b.HasOne("ALUXION.Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ALUXION.Domain.UserAddress", b =>
                {
                    b.HasOne("ALUXION.Domain.User", null)
                        .WithMany("Address")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ALUXION.Domain.Category", b =>
                {
                    b.Navigation("Amenities");
                });

            modelBuilder.Entity("ALUXION.Domain.Event", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("ALUXION.Domain.Stadium", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("ALUXION.Domain.User", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
