using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Engenhos.AzureDevOps.Aplicacao.Ordenacao;
using Engenhos.AzureDevOps.Dominio.Interfaces.Servicos;
using Engenhos.AzureDevOps.Dominio.WorkItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Engenhos.AzureDevOps.AplicativoWebReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        private readonly IServicoWorkItem servicoWorkItem;
        private readonly IServicoOrdenacao servicoOrdenacao;

        public WorkItemController(IServicoWorkItem servicoWorkItem, IServicoOrdenacao servicoOrdenacao)
        {
            this.servicoWorkItem = servicoWorkItem;
            this.servicoOrdenacao = servicoOrdenacao;
        }

        [HttpGet("[action]")]
        public IEnumerable<WorkItem> Index()
        {
            return this.servicoWorkItem.ObterTodos();
        }

        [HttpGet("[action]")]
        public IEnumerable<WorkItem> ObterWorkItemsPorOrdenacao(string nomeOrdenacao)
        {
            List<WorkItem> workitems = this.servicoWorkItem.ObterTodos().ToList();
            servicoOrdenacao.SelecionarNovaOrdenacao(nomeOrdenacao);
            return servicoOrdenacao.ObterWorkItemsOrdenados(workitems);
        }
    }
}