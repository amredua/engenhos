using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenhos.AzureDevOps.Infraestrutura.Ordenacao.Configuracao
{
    public class ConfiguracaoOrdenacao
    {
        public string Descricao { get; set; }
        public string NomeConfiguracao { get; set; }

        public List<Atributo> Atributos { get; set; }
    }
}
