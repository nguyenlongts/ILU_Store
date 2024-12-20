﻿// <auto-generated />
using System;
using ILU_Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ILU_Store.Migrations
{
    [DbContext(typeof(IlustoreContext))]
    [Migration("20241205165906_initMySql")]
    partial class initMySql
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ILU_Store.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressID");

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("AddressName");

                    b.Property<bool>("DefaultAddress")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddressId")
                        .HasName("PK__Address__091C2A1BD3794EF9");

                    b.HasIndex("UserId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("ILU_Store.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("RoleId")
                        .HasName("PK__Role__8AFACE3AF5E889A2");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("ILU_Store.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId")
                        .HasName("PK__User__1788CCACE3472FE5");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ILU_Store.Models.Address", b =>
                {
                    b.HasOne("ILU_Store.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ILU_Store.Models.User", b =>
                {
                    b.HasOne("ILU_Store.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__User__RoleID__571DF1D5");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ILU_Store.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ILU_Store.Models.User", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
