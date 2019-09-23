using Engenhos.AzureDevOps.Dominio.WorkItems;
using System.Collections.Generic;

namespace Engenhos.AzureDevOps.Aplicacao.Ordenacao
{
    public interface IOrdenacaoWorkItems
    {
       void Ordenar(List<WorkItem> workItems);
    }
}
