using Engenhos.AzureDevOps.Dominio.WorkItems;
using Engenhos.AzureDevOps.Infraestrutura.ConfiguracaoEntidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engenhos.AzureDevOps.Infraestrutura.Contexto
{
    public class EngenhosAzureDevOpsContexto : DbContext
    {
        public DbSet<WorkItem> WorkItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EngenhosAzureDevOps; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ConfiguracaoWorkItem(modelBuilder.Entity<WorkItem>());
            
        }
    }
}
