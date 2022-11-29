﻿// <auto-generated />
using System;
using DoAnSem3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoAnSem3.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221129024337_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoAnSem3.Models.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("content")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("craateAt");

                    b.Property<string>("image");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("About");
                });

            modelBuilder.Entity("DoAnSem3.Models.Banking", b =>
                {
                    b.Property<int>("bankId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("bankName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime?>("createAt");

                    b.Property<int>("cusId");

                    b.Property<float>("rechange");

                    b.Property<bool>("status");

                    b.HasKey("bankId");

                    b.HasIndex("cusId");

                    b.ToTable("Banking");
                });

            modelBuilder.Entity("DoAnSem3.Models.Customer", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("password");

                    b.Property<string>("phone")
                        .IsRequired();

                    b.Property<string>("phoneNsp");

                    b.Property<int>("role");

                    b.Property<bool>("status");

                    b.Property<float?>("totalPrice");

                    b.HasKey("customerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DoAnSem3.Models.FreeBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("note")
                        .HasMaxLength(1000);

                    b.Property<string>("phone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Freeback");
                });

            modelBuilder.Entity("DoAnSem3.Models.NetworkServiceProvider", b =>
                {
                    b.Property<int>("nspId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("nspName")
                        .IsRequired();

                    b.Property<bool>("status");

                    b.HasKey("nspId");

                    b.ToTable("NetworkServiceProvider");
                });

            modelBuilder.Entity("DoAnSem3.Models.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createAt");

                    b.Property<int?>("customerId");

                    b.Property<string>("description");

                    b.Property<string>("nameCustomer");

                    b.Property<string>("nameService");

                    b.Property<string>("numberPhone");

                    b.Property<int>("productId");

                    b.Property<bool>("status");

                    b.HasKey("orderId");

                    b.HasIndex("customerId");

                    b.HasIndex("productId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("DoAnSem3.Models.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasMaxLength(1000);

                    b.Property<int>("nspId");

                    b.Property<float>("price");

                    b.Property<string>("productName")
                        .HasMaxLength(200);

                    b.Property<int>("svId");

                    b.HasKey("productId");

                    b.HasIndex("nspId");

                    b.HasIndex("svId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DoAnSem3.Models.Service", b =>
                {
                    b.Property<int>("svId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<bool>("status");

                    b.Property<string>("svName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("svId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("DoAnSem3.Models.Banking", b =>
                {
                    b.HasOne("DoAnSem3.Models.Customer", "Customer")
                        .WithMany("Bankings")
                        .HasForeignKey("cusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DoAnSem3.Models.Order", b =>
                {
                    b.HasOne("DoAnSem3.Models.Customer")
                        .WithMany("Orders")
                        .HasForeignKey("customerId");

                    b.HasOne("DoAnSem3.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DoAnSem3.Models.Product", b =>
                {
                    b.HasOne("DoAnSem3.Models.NetworkServiceProvider", "NetworkServiceProvider")
                        .WithMany("Products")
                        .HasForeignKey("nspId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DoAnSem3.Models.Service", "Service")
                        .WithMany("Products")
                        .HasForeignKey("svId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
