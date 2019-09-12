using System;
using System.Collections.Generic;
using System.Text;
using UnimedAgendamentos.BLL.Models;
using UnimedAgendamentos.DAL.Context;
using Unimed.Agendamentos.BLL.Interfaces;


namespace Unimed.Agendamentos.DAL.Repository
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(UnimedAgendamentosDbContext context) : base(context) { }
    }
}
