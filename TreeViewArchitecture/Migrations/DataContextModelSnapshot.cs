﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreeViewArchitecture.Data;

#nullable disable

namespace TreeViewArchitecture.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TreeViewArchitecture.Models.NodeModel", b =>
                {
                    b.Property<int>("NodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NodeId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentNodeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NodeId");

                    b.HasIndex("ParentNodeId");

                    b.ToTable("Nodes");

                    b.HasData(
                        new
                        {
                            NodeId = 1,
                            IsActive = true,
                            NodeName = "Node 1",
                            ParentNodeId = 1,
                            StartDate = new DateTime(2024, 5, 25, 2, 30, 37, 622, DateTimeKind.Local).AddTicks(2947)
                        },
                        new
                        {
                            NodeId = 2,
                            IsActive = true,
                            NodeName = "Node 2",
                            ParentNodeId = 2,
                            StartDate = new DateTime(2024, 5, 25, 2, 30, 37, 622, DateTimeKind.Local).AddTicks(2961)
                        },
                        new
                        {
                            NodeId = 3,
                            IsActive = false,
                            NodeName = "Node 3",
                            ParentNodeId = 1,
                            StartDate = new DateTime(2024, 5, 25, 2, 30, 37, 622, DateTimeKind.Local).AddTicks(2963)
                        });
                });

            modelBuilder.Entity("TreeViewArchitecture.Models.NodeModel", b =>
                {
                    b.HasOne("TreeViewArchitecture.Models.NodeModel", "ParentNode")
                        .WithMany("ChildNodes")
                        .HasForeignKey("ParentNodeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ParentNode");
                });

            modelBuilder.Entity("TreeViewArchitecture.Models.NodeModel", b =>
                {
                    b.Navigation("ChildNodes");
                });
#pragma warning restore 612, 618
        }
    }
}
