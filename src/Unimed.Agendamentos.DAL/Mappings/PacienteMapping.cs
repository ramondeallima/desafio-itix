using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UnimedAgendamentos.BLL.Models;

namespace UnimedAgendamentos.DAL.Mappings
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(a => a.Telefone)
                .IsRequired()
                .HasColumnType("varchar(20)");

            // 1 : N => Paciente : Agendamentos 
            builder.HasMany(p => p.Agendamentos)
                .WithOne(a => a.Paciente)
                .HasForeignKey(p => p.PacienteId);

            builder.ToTable("Pacientes", "Agendamento");
        }
    }
}