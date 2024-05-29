﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using course.Server.Data;

#nullable disable

namespace course.Server.Migrations
{
    [DbContext(typeof(InsuranceCompanyContext))]
    [Migration("20240529101204_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("course.Server.Data.Agent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateOnly>("DateHired")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("course.Server.Data.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("course.Server.Data.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ContractSignedDate")
                        .HasColumnType("date");

                    b.Property<int>("InsuranceCaseId")
                        .HasColumnType("int");

                    b.Property<int>("ValidityTerm")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("ClientId");

                    b.HasIndex("InsuranceCaseId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("course.Server.Data.InsuranceCase", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AnnualCost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TypeID");

                    b.ToTable("InsuranceCases");
                });

            modelBuilder.Entity("course.Server.Data.InsuranceType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("InsuranceTypes");
                });

            modelBuilder.Entity("course.Server.Data.Contract", b =>
                {
                    b.HasOne("course.Server.Data.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("course.Server.Data.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("course.Server.Data.InsuranceCase", "InsuranceCase")
                        .WithMany()
                        .HasForeignKey("InsuranceCaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Client");

                    b.Navigation("InsuranceCase");
                });

            modelBuilder.Entity("course.Server.Data.InsuranceCase", b =>
                {
                    b.HasOne("course.Server.Data.InsuranceType", "InsuranceType")
                        .WithMany()
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InsuranceType");
                });
#pragma warning restore 612, 618
        }
    }
}