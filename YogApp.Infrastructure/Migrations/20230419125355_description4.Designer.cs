﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using YogApp.Infrastructure.Data;

#nullable disable

namespace YogApp.Infrastructure.Migrations
{
    [DbContext(typeof(YogAppDbContext))]
    [Migration("20230419125355_description4")]
    partial class description4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("YogApp.Domain.Rooms.RoomEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("YogApp.Domain.SessionParticipants.SessionParticipantEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("HasCancelled")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("MatNumber")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SessionEntityId")
                        .HasColumnType("uuid");

                    b.Property<string>("TimeStampSignUp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserAzureId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SessionEntityId");

                    b.ToTable("sessionParticipants");
                });

            modelBuilder.Entity("YogApp.Domain.Sessions.SessionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFull")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TeacherAzureId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TimeStampAdded")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("sessions");
                });

            modelBuilder.Entity("YogApp.Domain.SessionParticipants.SessionParticipantEntity", b =>
                {
                    b.HasOne("YogApp.Domain.Sessions.SessionEntity", null)
                        .WithMany("Participants")
                        .HasForeignKey("SessionEntityId");
                });

            modelBuilder.Entity("YogApp.Domain.Sessions.SessionEntity", b =>
                {
                    b.HasOne("YogApp.Domain.Rooms.RoomEntity", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("YogApp.Domain.Sessions.SessionEntity", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
