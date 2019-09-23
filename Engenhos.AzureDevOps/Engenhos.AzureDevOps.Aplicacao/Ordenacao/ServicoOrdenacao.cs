using Engenhos.AzureDevOps.Dominio.WorkItems;
using Engenhos.AzureDevOps.Infraestrutura.Ordenacao.Configuracao;
using System.Collections.Generic;

namespace Engenhos.AzureDevOps.Aplicacao.Ordenacao
{
    public class ServicoOrdenacao : IServicoOrdenacao
    {
        IOrdenacaoWorkItems ordenacaoWorkItems;

        public ServicoOrdenacao(IOrdenacaoWorkItems ordenacaoWorkItems)
        {
            this.ordenacaoWorkItems = ordenacaoWorkItems;
        }

        public void SelecionarNovaOrdenacao(string nomeOrdenacao)
        {
            ConfiguracaoOrdenacao configuracao = ServicoConfiguracao.ObterConfiguracao(nomeOrdenacao);
            this.ordenacaoWorkItems = new OrdenacaoWorkItems(configuracao);
        }

        public List<WorkItem> ObterWorkItemsOrdenados(List<WorkItem> workItems)
        {
            if (workItems == null)
                throw new OrdenacaoException();

            ordenacaoWorkItems.Ordenar(workItems);

            return workItems;
        }
    }
}
