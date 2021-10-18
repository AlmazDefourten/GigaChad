﻿// <auto-generated />
using System;
using ChadCalendar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChadCalendar.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211018162508_AddedRequirements")]
    partial class AddedRequirements
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ChadCalendar.Models.Duty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Accessed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Frequency")
                        .HasColumnType("TEXT");

                    b.Property<int>("Multiplier")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NRepetitions")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Duty");
                });

            modelBuilder.Entity("ChadCalendar.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("RemindEveryNDays")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeZone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkingHoursFrom")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkingHoursTo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChadCalendar.Models.Duty", b =>
                {
                    b.HasOne("ChadCalendar.Models.User", "User")
                        .WithMany("Duties")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChadCalendar.Models.User", b =>
                {
                    b.Navigation("Duties");
                });
#pragma warning restore 612, 618
        }
    }
}
