using Microsoft.EntityFrameworkCore.Migrations;

namespace Unimed.Agendamentos.DAL.Migrations
{
    public partial class campocpfaddparapaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                schema: "Agendamento",
                table: "Pacientes",
                type: "varchar(11)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                schema: "Agendamento",
                table: "Pacientes");
        }
    }
}
