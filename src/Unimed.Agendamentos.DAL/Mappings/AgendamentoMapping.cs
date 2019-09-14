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

            builder.Property(a => a.Observacao)
                .HasColumnType("varchar(1000)");

            builder.ToTable("Agendamentos", "Agendamento");

        }
    }
}
