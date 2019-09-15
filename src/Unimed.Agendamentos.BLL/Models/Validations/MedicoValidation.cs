using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Unimed.Agendamentos.BLL.Models.Validations.Documentos;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.BLL.Models.Validations
{
    public class MedicoValidation : AbstractValidator<Medico>
    {
        public MedicoValidation()
        {
                
        }
    }
}