using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public WorkItemController(IServicoWorkItem servicoWorkItem)
        {
            this.servicoWorkItem = servicoWorkItem;
        }

        [HttpGet("[action]")]
        public IEnumerable<WorkItem> Index()
        {
            return this.servicoWorkItem.ObterTodos();
        }
    }
}