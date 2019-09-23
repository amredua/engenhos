using System;
using Engenhos.AzureDevOps.CrossCutting;
using Engenhos.AzureDevOps.Dominio.Interfaces.Servicos;
using Engenhos.AzureDevOps.Infraestrutura.AzureDevOps;
using Microsoft.Extensions.Configuration;
using Autofac;
using System.Linq;
using Engenhos.AzureDevOps.Dominio.WorkItems;

namespace Engenhos.AzureDevOps.AplicativoConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var uri = config["UriAzureDevOps"];
            var projeto = config["ProjetoAzureDevOps"];

            var listaWorkItems = new ImportarWorkItems(uri, projeto).ObterListaWorkItems();

            Console.WriteLine("Aguarde, processando...");

            while (!listaWorkItems.IsCompleted) ;

            Console.WriteLine("Iniciar Processo de Importação para Base de Dados.");

            Console.ReadKey();

            var container = new IoC().Container;

            DateTime dataCadastro = DateTime.Now;

            using (var scope = container.BeginLifetimeScope())
            {
                var servico = scope.Resolve<IServicoWorkItem>();

                foreach (var item in listaWorkItems.Result.ToList())
                {
                    var workItem = new WorkItem
                    {
                        IdWorkItem = item.Id.Value
                    };

                    foreach(var valor in item.Fields)
                    {
                        if(valor.Key == "System.Title")
                        workItem.Titulo = valor.Value.ToString();

                        if (valor.Key == "System.WorkItemType")
                            workItem.Tipo = valor.Value.ToString();

                        if (valor.Key == "System.ChangedDate")
                            workItem.DataCriacaoWorkItem = DateTime.Parse(valor.Value.ToString());
                    }

                    workItem.DataCadastro = dataCadastro;
                    servico.Adicionar(workItem);
                }
            }
        }
    }
}
