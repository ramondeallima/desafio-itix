using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Unimed.Agendamentos.BLL.Models.Validations.Documentos;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.BLL.Models.Validations
{
    public class PacienteValidation : AbstractValidator<Paciente>
    {
        public PacienteValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O {PropertyName} precisa ser fornecido");

            RuleFor(p => p.Telefone)
                .NotEmpty().WithMessage("O {PropertyName} precisa ser fornecido")
                .Length(10, 11).WithMessage("O { PropertyName} deve ter 10 ou 11 números, incluindo o DDD");

            RuleFor(p => p.Cpf.Length).Equal(ValidacaoCPF.TamanhoCPF)
                .WithMessage("O CPF deve ter {ComparisonValue} dígitos");

            RuleFor(p => ValidacaoCPF.Validar(p.Cpf)).Equal(true)
                .WithMessage("O documento fornecido é inválido");

            RuleFor(p => ValidacaoData.ValidarDataNascimento(p.DataNascimento)).Equal(true)
                .WithMessage("Anos menores que 1900 e maiores que " + DateTime.Now.Year + "não são válidos para data de nascimento!");
                
        }
    }
}