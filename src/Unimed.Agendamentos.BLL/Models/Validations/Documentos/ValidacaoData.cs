using System;
using System.Collections.Generic;
using System.Text;

namespace Unimed.Agendamentos.BLL.Models.Validations.Documentos
{
    public static class ValidacaoData
    {
        public static bool ValidarDataNascimento(DateTime dataFornecida)
        {
            if (dataFornecida.Year < 1901 && dataFornecida.Year > DateTime.Now.Year) return false;

            return true;
        }

        public static DateTime ObterDataAtual()
        {
            return DateTime.Now;
        }
    }
}
