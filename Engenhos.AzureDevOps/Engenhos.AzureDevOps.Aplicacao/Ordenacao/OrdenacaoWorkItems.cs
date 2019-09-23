using Engenhos.AzureDevOps.Dominio.WorkItems;
using Engenhos.AzureDevOps.Infraestrutura.Ordenacao.Configuracao;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Engenhos.AzureDevOps.Aplicacao.Ordenacao
{
    public class OrdenacaoWorkItems : IComparer<WorkItem>, IOrdenacaoWorkItems
    {
        private const int INDICE_ATRIBUTO = 0;
        private const int INDECE_ORDENACAO = 1;
        private const string DESCENDENTE = "DESC";
        private string[] atributos;
        private WorkItem workItem = new WorkItem();

        public OrdenacaoWorkItems() { }

        public OrdenacaoWorkItems(params string[] atributos)
        {
            this.atributos = atributos;
        }

        public OrdenacaoWorkItems(ConfiguracaoOrdenacao configuracao)
        {
            if (configuracao == null)
                throw new ArgumentNullException("Parametro nulo");

            if(configuracao.Atributos.Count == 0)
                throw new ArgumentNullException("Arquivo sem atributos");

            int posicao = 0;
            atributos = new string[configuracao.Atributos.Count];

            foreach(Atributo atributo in configuracao.Atributos)
            {
                atributos[posicao] = string.Concat(atributo.Nome, ".", atributo.Ordenacao);
                posicao++;
            }
        }

        public int Compare(WorkItem workItemX, WorkItem workItemY)
        {
            int retorno = 0, posicao = 0;

            while (retorno == 0 && posicao < atributos.Length)
            {
                string atributo;
                string ordenacao;
                ObterAtributosOrdenacao(posicao, out atributo, out ordenacao);

                object valorAtributoX;
                object valorAtributoY;
                ObterValoresAtributos(workItemX, workItemY, atributo, out valorAtributoX, out valorAtributoY);

                retorno = ObterOrdenacao(retorno, ordenacao, valorAtributoX, valorAtributoY);
                posicao++;
            }

            return retorno;
        }

        private void ObterValoresAtributos(WorkItem workItemX, WorkItem workItemY, string atributo, out object valorAtributoX, out object valorAtributoY)
        {
            PropertyDescriptor propriedade = TypeDescriptor.GetProperties(workItem)[atributo];

            valorAtributoX = propriedade.GetValue(workItemX);
            valorAtributoY = propriedade.GetValue(workItemY);
        }

        private void ObterAtributosOrdenacao(int posicao, out string atributo, out string ordenacao)
        {
            string[] atributoOrdenacao = atributos[posicao].Split('.');

            atributo = atributoOrdenacao[INDICE_ATRIBUTO];
            ordenacao = atributoOrdenacao[INDECE_ORDENACAO];
        }

        private static int ObterOrdenacao(int retorno, string ordenacao, object valorAtributoX, object valorAtributoY)
        {
            switch (ordenacao)
            {
                case DESCENDENTE:
                    retorno = ((IComparable)valorAtributoY).CompareTo(valorAtributoX);
                    break;
                default:
                    retorno = ((IComparable)valorAtributoX).CompareTo(valorAtributoY);
                    break;
            }
            return retorno;
        }

        public void Ordenar(List<WorkItem> workItems)
        {
            workItems.Sort(this);
        }
    }
}
