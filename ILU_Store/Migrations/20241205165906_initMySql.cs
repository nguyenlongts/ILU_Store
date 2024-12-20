﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILU_Store.Migrations
{
    /// <inheritdoc />
    public partial class initMySql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__8AFACE3AF5E889A2", x => x.RoleID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
    name: "User",
    columns: table => new
    {
        UserID = table.Column<int>("int", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
        Username = table.Column<string>("varchar(255)", nullable: false),
        Password = table.Column<string>("varchar(255)", nullable: false),
        Email = table.Column<string>("varchar(255)", nullable: false),
        Phone = table.Column<string>("varchar(255)", nullable: false),
        RoleID = table.Column<int>("int", nullable: false),
        Status = table.Column<int>("int", nullable: false),
        DoB = table.Column<DateTime>("timestamp", nullable: false),
        Gender = table.Column<int>("int", nullable: false),
        FullName = table.Column<string>("varchar(255)", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK__User__1788CCACE3472FE5", x => x.UserID);
        table.ForeignKey(
            name: "FK__User__RoleID__571DF1D5",
            column: x => x.RoleID,
            principalTable: "Role",
            principalColumn: "RoleID",
            onDelete: ReferentialAction.Cascade);
    });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    AddressName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DefaultAddress = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Address__091C2A1BD3794EF9", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
