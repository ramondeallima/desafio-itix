using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Unimed.Agendamentos.UI.ViewModels;

namespace Unimed.Agendamentos.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Unimed.Agendamentos.UI.ViewModels.AgendamentoViewModel> AgendamentoViewModel { get; set; }
        public DbSet<Unimed.Agendamentos.UI.ViewModels.MedicoViewModel> MedicoViewModel { get; set; }
    }
}