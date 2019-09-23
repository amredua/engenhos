using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Engenhos.AzureDevOps.Infraestrutura.AzureDevOps
{
    public class ImportarWorkItems
    {
        readonly string _uri;
        readonly string _personalAccessToken;
        readonly string _project;

        /// <summary>
        /// Construtor. Obtem os valores da organização
        /// </summary>
        public ImportarWorkItems(string uri, string projeto)
        {
            _uri = uri;
            _personalAccessToken = AccessTokenAzureDevOps.ObterTokenAcessoAzureDevOps();
            _project = projeto;
        }

        /// <summary>
        /// Executa a WIQL query para obter o retorno de uma lista de WorkItems usando o .NET client library
        /// </summary>
        /// <returns>Lista de Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem</returns>
        public async Task<List<WorkItem>> ObterListaWorkItems()
        {
            Uri uri = new Uri(_uri);
            string personalAccessToken = _personalAccessToken;
            string project = _project;

            VssBasicCredential credentials = new VssBasicCredential("", _personalAccessToken);

            //Cria o objeto wiql e com a query que será executada
            Wiql wiql = new Wiql()
            {
                Query = "Select [State], [Title] " +
                        "From WorkItems " +
                        //"Where [Work Item Type] = '[Any]' " +
                        "Where [System.TeamProject] = '" + project + "' " +
                        //"And [System.State] <> 'Closed' " +
                        "Order By [State] Asc, [Changed Date] Desc"
            };

            //Cria uma intância para work item tracking http client
            using (WorkItemTrackingHttpClient workItemTrackingHttpClient = new WorkItemTrackingHttpClient(uri, credentials))
            {
                try
                {
                    //executa a query para obter o resultado de uma lista de work items
                    WorkItemQueryResult workItemQueryResult = await workItemTrackingHttpClient.QueryByWiqlAsync(wiql);


                    //se não ocorrer nenhum erro                
                    if (workItemQueryResult.WorkItems.Count() != 0)
                    {
                        //need to get the list of our work item ids and put them into an array
                        List<int> list = new List<int>();
                        foreach (var item in workItemQueryResult.WorkItems)
                        {
                            list.Add(item.Id);
                        }
                        int[] arr = list.ToArray();

                        //build a list of the fields we want to see
                        string[] fields = new string[5];
                        fields[0] = "System.Id";
                        fields[1] = "System.Title";
                        fields[2] = "System.State";
                        fields[3] = "System.WorkItemType";
                        fields[4] = "System.ChangedDate";

                        //get work items for the ids found in query
                        var workItems = await workItemTrackingHttpClient.GetWorkItemsAsync(arr, fields, workItemQueryResult.AsOf);

                        Console.WriteLine("Resultado busca: {0} items encontrados", workItems.Count);

                        //Exibe os valores no console
                        foreach (var workItem in workItems)
                        {
                            Console.WriteLine("{0}          {1}                     {2}", workItem.Id, workItem.Fields["System.Title"], workItem.Fields["System.State"]);
                        }

                        return workItems;
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }

                return null;
            }
        }
    }

}
