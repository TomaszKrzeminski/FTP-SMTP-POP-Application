﻿// <auto-generated />
using MailOperations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace MailOperations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191217172628_DatabaseChange1")]
    partial class DatabaseChange1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MailOperations.Models.SettingsData", b =>
                {
                    b.Property<int>("SettingsDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FTP_Login");

                    b.Property<string>("FTP_Password");

                    b.Property<string>("FTP_Path");

                    b.Property<string>("Pop3_EmailAddress");

                    b.Property<bool>("Pop3_EnableSsl");

                    b.Property<string>("Pop3_Login");

                    b.Property<string>("Pop3_Password");

                    b.Property<string>("Pop3_SMTP_Host");

                    b.Property<int>("Pop3_SMTP_Port");

                    b.Property<string>("RequestUriString");

                    b.Property<string>("SMTP_EmailAddress");

                    b.Property<bool>("SMTP_EnableSsl");

                    b.Property<string>("SMTP_Host");

                    b.Property<string>("SMTP_Login");

                    b.Property<string>("SMTP_Password");

                    b.Property<int>("SMTP_Port");

                    b.HasKey("SettingsDataId");

                    b.ToTable("Settings");
                });
#pragma warning restore 612, 618
        }
    }
}