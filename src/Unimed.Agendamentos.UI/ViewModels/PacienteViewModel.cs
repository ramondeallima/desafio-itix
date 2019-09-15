using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unimed.Agendamentos.UI.ViewModels
{
    public class PacienteViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [StringLength(11, ErrorMessage = "O número precisa ter entre {2} e {1} dígitos, incluindo o DDD", MinimumLength = 10)]
        public string Telefone { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "O número precisa ter 11 dígitos", MinimumLength = 11)]
        public string Cpf { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        public IEnumerable<AgendamentoViewModel> Agendamentos { get; set; }
    }
}
