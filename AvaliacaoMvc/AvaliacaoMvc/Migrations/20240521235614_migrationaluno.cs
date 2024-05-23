﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvaliacaoMvc.Migrations
{
    /// <inheritdoc />
    public partial class migrationaluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DiaPagto",
                table: "CadAluno",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Mensalidade",
                table: "CadAluno",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaPagto",
                table: "CadAluno");

            migrationBuilder.DropColumn(
                name: "Mensalidade",
                table: "CadAluno");
        }
    }
}