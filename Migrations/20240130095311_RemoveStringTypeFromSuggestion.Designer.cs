﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using suggestionbox.Data;

#nullable disable

namespace suggestionbox.Migrations
{
    [DbContext(typeof(suggestionboxContext))]
    [Migration("20240130095311_RemoveStringTypeFromSuggestion")]
    partial class RemoveStringTypeFromSuggestion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("suggestionbox.Models.Suggestion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("categories")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("suggestionTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("suggestionTypeId");

                    b.ToTable("Suggestion");
                });

            modelBuilder.Entity("suggestionbox.Models.SuggestionType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("require_daterange")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("SuggestionType");
                });

            modelBuilder.Entity("suggestionbox.Models.Suggestion", b =>
                {
                    b.HasOne("suggestionbox.Models.SuggestionType", "suggestionType")
                        .WithMany("suggestions")
                        .HasForeignKey("suggestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("suggestionType");
                });

            modelBuilder.Entity("suggestionbox.Models.SuggestionType", b =>
                {
                    b.Navigation("suggestions");
                });
#pragma warning restore 612, 618
        }
    }
}
