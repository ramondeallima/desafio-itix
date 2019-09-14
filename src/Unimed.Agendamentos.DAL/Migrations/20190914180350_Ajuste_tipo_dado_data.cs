using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unimed.Agendamentos.DAL.Migrations
{
    public partial class Ajuste_tipo_dado_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                schema: "Agendamento",
                table: "Agendamentos",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true,
                oldDefaultValueSql: " ");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InicioAtendimento",
                schema: "Agendamento",
                table: "Agendamentos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FimAtendimento",
                schema: "Agendamento",
                table: "Agendamentos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                schema: "Agendamento",
                table: "Agendamentos",
                type: "varchar(1000)",
                nullable: true,
                defaultValueSql: " ",
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InicioAtendimento",
                schema: "Agendamento",
                table: "Agendamentos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FimAtendimento",
                schema: "Agendamento",
                table: "Agendamentos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
