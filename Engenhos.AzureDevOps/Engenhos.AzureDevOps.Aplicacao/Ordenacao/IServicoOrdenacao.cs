using Engenhos.AzureDevOps.Dominio.WorkItems;
using System.Collections.Generic;

namespace Engenhos.AzureDevOps.Aplicacao.Ordenacao
{
    public interface IServicoOrdenacao
    {
        void SelecionarNovaOrdenacao(string nomeOrdenacao);
        List<WorkItem> ObterWorkItemsOrdenados(List<WorkItem> workItems);
    }
}
