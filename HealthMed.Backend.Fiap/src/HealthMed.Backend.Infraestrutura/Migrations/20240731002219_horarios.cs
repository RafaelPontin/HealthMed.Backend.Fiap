using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMed.Backend.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class horarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Horarios_HorariosId",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "HorariosId",
                table: "Agendamentos",
                newName: "HorarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_HorariosId",
                table: "Agendamentos",
                newName: "IX_Agendamentos_HorarioId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioCriacao",
                table: "Agendamentos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Horarios_HorarioId",
                table: "Agendamentos",
                column: "HorarioId",
                principalTable: "Horarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Horarios_HorarioId",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "HorarioId",
                table: "Agendamentos",
                newName: "HorariosId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_HorarioId",
                table: "Agendamentos",
                newName: "IX_Agendamentos_HorariosId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioCriacao",
                table: "Agendamentos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Horarios_HorariosId",
                table: "Agendamentos",
                column: "HorariosId",
                principalTable: "Horarios",
                principalColumn: "Id");
        }
    }
}
