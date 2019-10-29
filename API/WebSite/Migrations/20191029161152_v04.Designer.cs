﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSite;

namespace WebSite.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191029161152_v04")]
    partial class v04
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("WebSite.Domains.AboutDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AboutFullText")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AboutDomains");
                });

            modelBuilder.Entity("WebSite.Domains.NewsDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("NewsCreateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("NewsFullText")
                        .HasColumnType("TEXT");

                    b.Property<string>("NewsImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("NewsName")
                        .HasColumnType("TEXT");

                    b.Property<string>("NewsShortText")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NewsDomain");
                });

            modelBuilder.Entity("WebSite.Domains.UserDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserLogin")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserPass")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserDomain");
                });
#pragma warning restore 612, 618
        }
    }
}
