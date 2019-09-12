using System;
using System.Collections.Generic;
using System.Text;
using UnimedAgendamentos.BLL.Models;
using Unimed.Agendamentos.BLL.Interfaces;
using UnimedAgendamentos.DAL.Context;

namespace Unimed.Agendamentos.DAL.Repository
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentosRepository
    {
        public AgendamentoRepository(UnimedAgendamentosDbContext context) : base(context) { }

    }
}
