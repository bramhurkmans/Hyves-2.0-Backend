﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserService.Data;

#nullable disable

namespace UserService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserService.Models.Friendship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FriendRequestFlag")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RequestTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("RequestedBy_Id")
                        .HasColumnType("int");

                    b.Property<int>("RequestedToId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestedBy_Id");

                    b.HasIndex("RequestedToId");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("UserService.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserService.Models.Friendship", b =>
                {
                    b.HasOne("UserService.Models.User", "RequestedBy")
                        .WithMany()
                        .HasForeignKey("RequestedBy_Id");

                    b.HasOne("UserService.Models.User", "RequestedTo")
                        .WithMany()
                        .HasForeignKey("RequestedToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestedBy");

                    b.Navigation("RequestedTo");
                });

            modelBuilder.Entity("UserService.Models.User", b =>
                {
                    b.HasOne("UserService.Models.User", null)
                        .WithMany("Friends")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("UserService.Models.User", b =>
                {
                    b.Navigation("Friends");
                });
#pragma warning restore 612, 618
        }
    }
}
