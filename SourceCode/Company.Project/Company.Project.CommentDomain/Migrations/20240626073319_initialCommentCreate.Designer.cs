﻿// <auto-generated />
using System;
using Company.Project.CommentDomain.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Company.Project.CommentDomain.Migrations
{
    [DbContext(typeof(CommentDbContext))]
    [Migration("20240626073319_initialCommentCreate")]
    partial class initialCommentCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Company.Project.CommentDomain.AppServices.DTOs.CommentDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOnDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<Guid>("GUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("ModifiedOnDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}