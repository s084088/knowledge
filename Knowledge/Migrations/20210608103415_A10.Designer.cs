﻿// <auto-generated />
using System;
using Knowledge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Knowledge.Migrations
{
    [DbContext(typeof(KnowledgeDB))]
    [Migration("20210608103415_A10")]
    partial class A10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Knowledge.Tables.KLLevel", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4")
                        .HasMaxLength(63);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeleteFlag")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Final")
                        .HasColumnType("int");

                    b.Property<int>("Key")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(2047);

                    b.Property<string>("ParentID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.ToTable("KL_Level");
                });

            modelBuilder.Entity("Knowledge.Tables.KLNode", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4")
                        .HasMaxLength(63);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeleteFlag")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LevelID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4");

                    b.Property<string>("PointID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4");

                    b.Property<string>("ProcessID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4");

                    b.Property<string>("TypeID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("LevelID");

                    b.HasIndex("PointID");

                    b.HasIndex("ProcessID");

                    b.HasIndex("TypeID");

                    b.ToTable("KL_Node");
                });

            modelBuilder.Entity("Knowledge.Tables.KLPoint", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4")
                        .HasMaxLength(63);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeleteFlag")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Explain")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(2047);

                    b.Property<string>("LevelID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("ProcessID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4");

                    b.Property<string>("TypeID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("LevelID");

                    b.HasIndex("ProcessID");

                    b.HasIndex("TypeID");

                    b.ToTable("KL_Point");
                });

            modelBuilder.Entity("Knowledge.Tables.NKLine", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4")
                        .HasMaxLength(63);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeleteFlag")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SourceID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4");

                    b.Property<string>("TargetID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("SourceID");

                    b.HasIndex("TargetID");

                    b.ToTable("N_K_Line");
                });

            modelBuilder.Entity("Knowledge.Tables.NKNode", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4")
                        .HasMaxLength(63);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeleteFlag")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("N_K_Node");
                });

            modelBuilder.Entity("Knowledge.Tables.KLLevel", b =>
                {
                    b.HasOne("Knowledge.Tables.KLLevel", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("Knowledge.Tables.KLNode", b =>
                {
                    b.HasOne("Knowledge.Tables.KLLevel", "Level")
                        .WithMany()
                        .HasForeignKey("LevelID");

                    b.HasOne("Knowledge.Tables.KLPoint", "Point")
                        .WithMany("Nodes")
                        .HasForeignKey("PointID");

                    b.HasOne("Knowledge.Tables.KLLevel", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessID");

                    b.HasOne("Knowledge.Tables.KLLevel", "Type")
                        .WithMany()
                        .HasForeignKey("TypeID");
                });

            modelBuilder.Entity("Knowledge.Tables.KLPoint", b =>
                {
                    b.HasOne("Knowledge.Tables.KLLevel", "Level")
                        .WithMany()
                        .HasForeignKey("LevelID");

                    b.HasOne("Knowledge.Tables.KLLevel", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessID");

                    b.HasOne("Knowledge.Tables.KLLevel", "Type")
                        .WithMany()
                        .HasForeignKey("TypeID");
                });

            modelBuilder.Entity("Knowledge.Tables.NKLine", b =>
                {
                    b.HasOne("Knowledge.Tables.NKNode", "Source")
                        .WithMany()
                        .HasForeignKey("SourceID");

                    b.HasOne("Knowledge.Tables.NKNode", "Target")
                        .WithMany()
                        .HasForeignKey("TargetID");
                });
#pragma warning restore 612, 618
        }
    }
}