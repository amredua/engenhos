using Engenhos.AzureDevOps.Dominio.Interfaces.Repositorios;
using Engenhos.AzureDevOps.Dominio.WorkItems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engenhos.AzureDevOps.Infraestrutura.Repositorios
{
    public class RepositorioWorkItem : RepositorioBase<WorkItem>, IRepositorioWorkItem
    {
        public RepositorioWorkItem(DbContext context)
          : base(context)
        {

        }
    }
}
