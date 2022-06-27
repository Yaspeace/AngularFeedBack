﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAngularWebApi.TestAngularDB;

#nullable disable

namespace TestAngularWebApi.Migrations
{
    [DbContext(typeof(TestAngularDbContext))]
    [Migration("20220624162806_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TestAngularWebApi.TestAngularDB.TableModels.Contact", b =>
                {
                    b.Property<int?>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ContactId"), 1L, 1);

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("TestAngularWebApi.TestAngularDB.TableModels.Message", b =>
                {
                    b.Property<int?>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("MessageId"), 1L, 1);

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("MessageContent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.HasIndex("ContactId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TestAngularWebApi.TestAngularDB.TableModels.MessageTheme", b =>
                {
                    b.Property<int?>("ThemeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ThemeId"), 1L, 1);

                    b.Property<string>("ThemeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThemeId");

                    b.ToTable("MessageThemes");
                });

            modelBuilder.Entity("TestAngularWebApi.TestAngularDB.TableModels.Message", b =>
                {
                    b.HasOne("TestAngularWebApi.TestAngularDB.TableModels.Contact", "Contact")
                        .WithMany("Messages")
                        .HasForeignKey("ContactId");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("TestAngularWebApi.TestAngularDB.TableModels.Contact", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}