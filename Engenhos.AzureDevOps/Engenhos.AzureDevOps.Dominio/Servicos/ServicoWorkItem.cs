using Engenhos.AzureDevOps.Dominio.Interfaces.Repositorios;
using Engenhos.AzureDevOps.Dominio.Interfaces.Servicos;
using Engenhos.AzureDevOps.Dominio.WorkItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engenhos.AzureDevOps.Dominio.Servicos
{
    public class ServicoWorkItem : ServicoBase<WorkItem>, IServicoWorkItem
    {
        private readonly IRepositorioWorkItem repositorio;

        public ServicoWorkItem(IRepositorioWorkItem repositorio)
            : base(repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
