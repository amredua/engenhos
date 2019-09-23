using Engenhos.AzureDevOps.Infraestrutura.Ordenacao.Configuracao;
using Engenhos.AzureDevOps.Infraestrutura.Serializacao;
using Microsoft.Extensions.Hosting.Internal;
using System.Collections.Generic;
using System.IO;

namespace Engenhos.AzureDevOps.Infraestrutura.Repositorios
{
    public static class RepositorioLocal
    {
        private const string EXTENSAO_ARQUIVO_XML = @".xml";
        private const string PASTA_LOCAL_PARA_CACHE_ARQUIVOS_ORDENACAO_EM_XML = @"Ordenacoes\";

        private static string ObterNomeDiretorioLocalSalvarConfiguracao()
        {
            string caminhoAplicacao = "";// HostingEnvironment.ApplicationPhysicalPath;
            if (string.IsNullOrEmpty(caminhoAplicacao))
                caminhoAplicacao = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\";

            return string.Concat(caminhoAplicacao, PASTA_LOCAL_PARA_CACHE_ARQUIVOS_ORDENACAO_EM_XML, @"\");
        }

        private static string ObterNomeArquivoConfiguracao(string nomeArquivo)
        {
            string diretorioLocalParaCacheOrdenacoes = ObterNomeDiretorioLocalSalvarConfiguracao();
            return string.Concat(diretorioLocalParaCacheOrdenacoes, nomeArquivo, EXTENSAO_ARQUIVO_XML);
        }

        public static ConfiguracaoOrdenacao ObterConfiguracao(string nomeArquivo, bool caminhoCompleto = false)
        {
            string nomeArquivoCompleto = nomeArquivo;

            if (!caminhoCompleto)
                nomeArquivoCompleto = ObterNomeArquivoConfiguracao(nomeArquivo);

            return ServicoSerializacao.DeserializarConfiguracao(nomeArquivoCompleto);
        }

        public static IEnumerable<ConfiguracaoOrdenacao>ObterTodasConfiguracoes()
        {
            List<ConfiguracaoOrdenacao> configuracoes = new List<ConfiguracaoOrdenacao>();

            string caminhoDiretorio = ObterNomeDiretorioLocalSalvarConfiguracao();
            string[] arquivos = Directory.GetFiles(caminhoDiretorio);

            foreach(string arquivo in arquivos)
            {
                ConfiguracaoOrdenacao configuracao = ObterConfiguracao(arquivo, true);
                configuracoes.Add(configuracao);
            }

            return configuracoes;
        }

        public static void GravarConfiguracao(ConfiguracaoOrdenacao configuracao)
        {
            string nomeArquivoConfiguracao = ObterNomeArquivoConfiguracao(configuracao.NomeConfiguracao);
            ServicoSerializacao.SerializarConfiguracao(configuracao, nomeArquivoConfiguracao);
        }
    }
}
