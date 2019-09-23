# Engenhos
=============================
Projeto de Integração com AzureDevOps
-----------------------------

Na aplicação do console, tem o arquivo de configuração onde pode alterar a url do azure devops, projeto.


Arquivo: appsettings.json

{
  "ProjetoAzureDevOps": "AshbellAdvogado",
  "UriAzureDevOps": "https://dev.azure.com/amrweb",
  "exclude": [
    "**/bin",
    "**/bower_components",
    "**/jspm_packages",
    "**/node_modules",
    "**/obj",
    "**/platforms"
  ]
}

Para a integração com o AzureDevOps usei o Token de Acesso, é configurado na biblioteca da Infraestrutura, para Manter a segurança.:
-----------------------------------------

./Engenhos.AzureDevOps\Engenhos.AzureDevOps.Infraestrutura\AzureDevOps\AccessTokenAzureDevOps.cs


namespace Engenhos.AzureDevOps.Infraestrutura.AzureDevOps
{
    internal class AccessTokenAzureDevOps
    {
        public static string ObterTokenAcessoAzureDevOps()
        {
            return "kqobpmmdduald3m4vfq5oocfnregcevl2rclco6sgagukefvqk5a";
        }
    }
}

Implementei o Migration, para criar a base de dados é necessário executar o update-migration na linha de comando do gerenciador de pacotes.
-------------------------------


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

