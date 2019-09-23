using System;

namespace Engenhos.AzureDevOps.Aplicacao.Ordenacao
{
    public class OrdenacaoException : Exception
    {
        public OrdenacaoException(string mensagem = "O conjunto de workitems está null") { }
    }
}
