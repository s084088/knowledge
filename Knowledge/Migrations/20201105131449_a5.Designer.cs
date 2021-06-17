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
    [Migration("20201105131449_a5")]
    partial class a5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Knowledge.Tables.Node", b =>
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

                    b.Property<string>("PointID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4");

                    b.Property<int>("Type00")
                        .HasColumnType("int");

                    b.Property<int>("Type01")
                        .HasColumnType("int");

                    b.Property<int>("Type10")
                        .HasColumnType("int");

                    b.Property<int>("Type11")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Value0")
                        .HasColumnType("int");

                    b.Property<int>("Value1")
                        .HasColumnType("int");

                    b.Property<int>("Value2")
                        .HasColumnType("int");

                    b.Property<int>("Value3")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PointID");

                    b.ToTable("KL_Node");
                });

            modelBuilder.Entity("Knowledge.Tables.Point", b =>
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

                    b.Property<int>("Final")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Value0")
                        .HasColumnType("int");

                    b.Property<int>("Value1")
                        .HasColumnType("int");

                    b.Property<int>("Value2")
                        .HasColumnType("int");

                    b.Property<int>("Value3")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("KL_Point");
                });

            modelBuilder.Entity("Knowledge.Tables.Value", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(63) CHARACTER SET utf8mb4")
                        .HasMaxLength(63);

                    b.Property<int>("Album")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeleteFlag")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Final")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("Lesson")
                        .HasColumnType("int");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("KL_Value");
                });

            modelBuilder.Entity("Knowledge.Tables.Node", b =>
                {
                    b.HasOne("Knowledge.Tables.Point", "Point")
                        .WithMany("Nodes")
                        .HasForeignKey("PointID");
                });
#pragma warning restore 612, 618
        }
    }
}