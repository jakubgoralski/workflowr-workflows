﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkflowR.Workflows.Infrastructure.EF.Contexts;

#nullable disable

namespace WorkflowR.Workflows.Infrastructure.EF.Migrations
{
    [DbContext(typeof(WorkflowsReadDbContext))]
    [Migration("20230601085422_AddedWorkflowsPart")]
    partial class AddedWorkflowsPart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("workflows")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkflowR.Workflows.Infrastructure.EF.ReadModels.TaskReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("InformManagerAboutProgress")
                        .HasColumnType("bit");

                    b.Property<bool>("InformUserOfNextTaskWhenThisIsCompleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("NextTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ShouldBeCompletedBefore")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TaskOwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TaskStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowId");

                    b.ToTable("task", "workflows");
                });

            modelBuilder.Entity("WorkflowR.Workflows.Infrastructure.EF.ReadModels.WorkflowReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FirstTaskInChain")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WorkflowStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("workflow", "workflows");
                });

            modelBuilder.Entity("WorkflowR.Workflows.Infrastructure.EF.ReadModels.TaskReadModel", b =>
                {
                    b.HasOne("WorkflowR.Workflows.Infrastructure.EF.ReadModels.WorkflowReadModel", "Workflow")
                        .WithMany("Tasks")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("WorkflowR.Workflows.Infrastructure.EF.ReadModels.WorkflowReadModel", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
