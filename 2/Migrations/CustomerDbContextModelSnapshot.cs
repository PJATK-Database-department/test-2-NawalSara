﻿// <auto-generated />
using System;
using APBD_Tutorial13.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APBD_Test2.Migrations
{
    [DbContext(typeof(CustomerDbContext))]
    partial class CustomerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APBD_Test2.Entities.Confectionery", b =>
                {
                    b.Property<int>("IdConectionery")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerItem")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdConectionery");

                    b.ToTable("Confectionery");

                    b.HasData(
                        new
                        {
                            IdConectionery = 1,
                            Name = "whatever",
                            PricePerItem = 2.3399999999999999,
                            Type = "gud"
                        },
                        new
                        {
                            IdConectionery = 2,
                            Name = "nme",
                            PricePerItem = 2.5600000000000001,
                            Type = "okei"
                        });
                });

            modelBuilder.Entity("APBD_Test2.Entities.Confectionery_Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int>("IdConfection")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdOrder", "IdConfection");

                    b.HasIndex("IdConfection");

                    b.ToTable("Confectionery_Order");

                    b.HasData(
                        new
                        {
                            IdOrder = 1,
                            IdConfection = 1,
                            Notes = "noted",
                            Quantity = 3
                        },
                        new
                        {
                            IdOrder = 2,
                            IdConfection = 2,
                            Notes = "NOTED",
                            Quantity = 4
                        });
                });

            modelBuilder.Entity("APBD_Test2.Entities.Customer", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            IdClient = 1,
                            Name = "John",
                            Surname = "Doe"
                        },
                        new
                        {
                            IdClient = 2,
                            Name = "Steve",
                            Surname = "Do"
                        });
                });

            modelBuilder.Entity("APBD_Test2.Entities.Employee", b =>
                {
                    b.Property<int>("IdEmpl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpl");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            IdEmpl = 1,
                            Name = "Jonny",
                            Surname = "Dough"
                        },
                        new
                        {
                            IdEmpl = 2,
                            Name = "Steven",
                            Surname = "Dou"
                        });
                });

            modelBuilder.Entity("APBD_Test2.Entities.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAccepted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinished")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpl")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOrder");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdEmpl");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            IdOrder = 1,
                            DateAccepted = new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateFinished = new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdClient = 1,
                            IdEmpl = 1,
                            Notes = "gibberish"
                        },
                        new
                        {
                            IdOrder = 2,
                            DateAccepted = new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateFinished = new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdClient = 2,
                            IdEmpl = 2,
                            Notes = "NotesHere"
                        });
                });

            modelBuilder.Entity("APBD_Test2.Entities.Confectionery_Order", b =>
                {
                    b.HasOne("APBD_Test2.Entities.Confectionery", "Conf")
                        .WithMany("Conf_orders")
                        .HasForeignKey("IdConfection")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_Test2.Entities.Order", "Order")
                        .WithMany("Сonf_orders")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APBD_Test2.Entities.Order", b =>
                {
                    b.HasOne("APBD_Tutorial13.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_Test2.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("IdEmpl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
