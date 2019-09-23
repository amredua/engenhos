using Engenhos.AzureDevOps.Infraestrutura.Repositorios;
using System.Collections.Generic;

namespace Engenhos.AzureDevOps.Infraestrutura.Ordenacao.Configuracao
{
    public static class ServicoConfiguracao
    {
        public static void GravarConfiguracao(ConfiguracaoOrdenacao configuracao)
        {
            RepositorioLocal.GravarConfiguracao(configuracao);
        }

        public static ConfiguracaoOrdenacao ObterConfiguracao(string nomeArquivo)
        {
            return RepositorioLocal.ObterConfiguracao(nomeArquivo);
        }

        public static IEnumerable<ConfiguracaoOrdenacao> ObterTodasConfiguracoes()
        {
            return RepositorioLocal.ObterTodasConfiguracoes();
        }
    }
}
