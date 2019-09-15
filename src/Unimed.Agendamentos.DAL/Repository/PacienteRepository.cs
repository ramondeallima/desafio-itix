using System;
using System.Collections.Generic;
using System.Text;
using UnimedAgendamentos.BLL.Models;
using UnimedAgendamentos.DAL.Context;
using Unimed.Agendamentos.BLL.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Unimed.Agendamentos.DAL.Repository
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(UnimedAgendamentosDbContext context) : base(context) { }

        public async Task<Paciente> ObterPacienteAgendamentos(Guid id)
        {
            return await Db.Pacientes.AsNoTracking()
                .Include(c => c.Agendamentos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
