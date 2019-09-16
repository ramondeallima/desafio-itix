using System;
using System.Collections.Generic;
using System.Text;
using Unimed.Agendamentos.BLL.Interfaces;
using UnimedAgendamentos.BLL.Models;


namespace Unimed.Agendamentos.BLL.Services.Validacao
{
    public class AgendamentoValidacao : BaseService, IAgendamentoValidacao
    {

        public AgendamentoValidacao(INotificador notificador) : base(notificador)
        {
            
        }

        public bool AgendaLivre(IEnumerable<Agendamento> agendamentos, Agendamento agendamento)
        {
            foreach (var agenda in agendamentos)
            {
                if (agendamento.InicioAtendimento < agenda.FimAtendimento &&
                    agendamento.FimAtendimento > agenda.InicioAtendimento)
                {
                    Notificar("O horário fornecido não está disponível.");
                    return false;
                }
            }
            return true;
        }
        public bool DateIsValid(Agendamento agendamento)
        {
            if (agendamento.InicioAtendimento <= DateTime.Now || agendamento.FimAtendimento <= DateTime.Now)
            {
                Notificar("A data de inicio e término não podem ser iguais ou inferiores a data atual.");
                return false;
            }

            if (agendamento.InicioAtendimento.DayOfWeek == 0 || (int)agendamento.InicioAtendimento.DayOfWeek == 6 ||
                agendamento.InicioAtendimento.Hour < 8 || agendamento.InicioAtendimento.TimeOfDay.TotalHours > 18 ||
                agendamento.FimAtendimento.Hour < 8 || agendamento.FimAtendimento.TimeOfDay.TotalHours > 18)
            {
                Notificar("Horário de agendamento: Segunda a Sexta das 8h às 18h.");
                return false;
            }

            if (agendamento.InicioAtendimento < DateTime.Now.AddDays(1))
            {
                Notificar("Os agendamentos só podem ser realizados com 24h de antecedência.");
                return false;
            }

            if (agendamento.FimAtendimento < agendamento.InicioAtendimento)
            {
                Notificar("A data e hórario de término não podem ser inferiores a data e hora de inicio.");
                return false;
            }

            var tempoConsulta = agendamento.FimAtendimento - agendamento.InicioAtendimento;

            if (tempoConsulta.TotalMinutes < 30 || tempoConsulta.TotalMinutes > 60)
            {
                Notificar("Uma consulta deve ter seu tempo de duração entre 30 minutos a 60 minutos.");
                return false;
            }

            return true;
        }
    }
}
