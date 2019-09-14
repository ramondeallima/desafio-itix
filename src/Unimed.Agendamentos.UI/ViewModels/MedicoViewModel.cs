using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unimed.Agendamentos.UI.ViewModels
{
    public class MedicoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("CRM")]
        [Required(ErrorMessage = "O CRM é obrigatório")]
        public string Crm { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [StringLength(11, ErrorMessage = "O número precisa ter entre {2} e {1} dígitos, incluindo o DDD", MinimumLength = 10)]
        public string Telefone { get; set; }

        public IEnumerable<AgendamentoViewModel> Agendamentos { get; set; }
    }
}
