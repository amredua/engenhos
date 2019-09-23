using Engenhos.AzureDevOps.Dominio.WorkItems;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engenhos.AzureDevOps.Infraestrutura.ConfiguracaoEntidade
{
    public class ConfiguracaoWorkItem
    {
        public ConfiguracaoWorkItem(EntityTypeBuilder<WorkItem> workitem)
        {
            workitem.HasKey(w => w.Id);

            workitem.HasIndex(w => w.IdWorkItem).IsUnique();

            workitem.Property(w => w.Tipo)
              .IsRequired();

            workitem.Property(w => w.Titulo)
             .IsRequired();

            workitem.Property(w => w.DataCriacaoWorkItem)
            .IsRequired();

            workitem.Property(w => w.DataCadastro)
           .IsRequired();
        }
    }
}
