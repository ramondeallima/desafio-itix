using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UnimedAgendamentos.BLL.Models;

namespace UnimedAgendamentos.DAL.Mappings
{
    public class AgendamentoMapping : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.InicioAtendimento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(a => a.FimAtendimento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(a => a.Observacao)
                .HasColumnType("varchar(1000)")
                .HasDefaultValueSql(" ");

            builder.ToTable("Agendamentos", "Agendamento");

        }
    }
}
