﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnimedAgendamentos.DAL.Context;

namespace Unimed.Agendamentos.DAL.Migrations
{
    [DbContext(typeof(UnimedAgendamentosDbContext))]
    [Migration("20190914180350_Ajuste_tipo_dado_data")]
    partial class Ajuste_tipo_dado_data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UnimedAgendamentos.BLL.Models.Agendamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("FimAtendimento");

                    b.Property<DateTime>("InicioAtendimento");

                    b.Property<Guid>("MedicoId");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("PacienteId");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Agendamentos","Agendamento");
                });

            modelBuilder.Entity("UnimedAgendamentos.BLL.Models.Medico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Medicos","Agendamento");
                });

            modelBuilder.Entity("UnimedAgendamentos.BLL.Models.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Pacientes","Agendamento");
                });

            modelBuilder.Entity("UnimedAgendamentos.BLL.Models.Agendamento", b =>
                {
                    b.HasOne("UnimedAgendamentos.BLL.Models.Medico", "Medico")
                        .WithMany("Agendamentos")
                        .HasForeignKey("MedicoId");

                    b.HasOne("UnimedAgendamentos.BLL.Models.Paciente", "Paciente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("PacienteId");
                });
#pragma warning restore 612, 618
        }
    }
}
