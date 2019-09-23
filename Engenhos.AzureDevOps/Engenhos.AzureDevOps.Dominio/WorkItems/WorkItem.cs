using System;
using System.Collections.Generic;
using System.Text;

namespace Engenhos.AzureDevOps.Dominio.WorkItems
{
    public class WorkItem
    {
        public int Id { get; set; }
        public int IdWorkItem { get; set; }
        public string Tipo { get; set;}
        public string Titulo { get; set; }
        public DateTime DataCriacaoWorkItem { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
