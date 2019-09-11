using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UnimedAgendamentos.BLL.Models;

namespace UnimedAgendamentos.DAL.Mappings
{
    public class MedicoMapping : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(m => m.Crm)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(m => m.Telefone)
                .IsRequired()
                .HasColumnType("varchar(20)");

            // 1 : N => Medico : Agendamentos 
            builder.HasMany(m => m.Agendamentos)
                .WithOne(a => a.Medico)
                .HasForeignKey(m => m.MedicoId);

            builder.ToTable("Medicos", "Agendamento");
        }
    }
}
