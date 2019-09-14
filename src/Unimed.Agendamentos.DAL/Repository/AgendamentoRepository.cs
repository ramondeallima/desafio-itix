using System;
using System.Collections.Generic;
using System.Text;
using UnimedAgendamentos.BLL.Models;
using Unimed.Agendamentos.BLL.Interfaces;
using UnimedAgendamentos.DAL.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Unimed.Agendamentos.DAL.Repository
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentosRepository
    {
        public AgendamentoRepository(UnimedAgendamentosDbContext context) : base(context) { }

        public async Task<Agendamento> ObterAgendamentoPaciente(Guid id)
        {
            return await Db.Agendas.AsNoTracking().Include(p => p.Paciente)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Agendamento>> ObterAgendamentosPacientes()
        {
            return await Db.Agendas.AsNoTracking().Include(p => p.Paciente)
                .OrderBy(a => a.InicioAtendimento).ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> ObterAgendamentosPorMedico(Guid medicoId)
        {
            return await Buscar(a => a.MedicoId == medicoId);
        }

        public async Task<IEnumerable<Agendamento>> ObterAgendamentosPorPaciente(Guid pacienteId)
        {
            return await Buscar(a => a.PacienteId == pacienteId);
        }
    }
}
