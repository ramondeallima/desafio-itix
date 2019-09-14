using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unimed.Agendamentos.DAL.Migrations
{
    public partial class Ajuste_tipo_data_paciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                schema: "Agendamento",
                table: "Pacientes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                schema: "Agendamento",
                table: "Pacientes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
