using Engenhos.AzureDevOps.Infraestrutura.Ordenacao.Configuracao;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Engenhos.AzureDevOps.Infraestrutura.Serializacao
{
    public static class ServicoSerializacao
    {
        private static void CriarDiretorioSeNaoExistir(string nomeArquivo)
        {
            string nomeDiretorio = Path.GetDirectoryName(nomeArquivo);
            if (!Directory.Exists(nomeDiretorio))
                Directory.CreateDirectory(nomeDiretorio);
        }

        public static void SerializarConfiguracao(ConfiguracaoOrdenacao configuracao, string nomeArquivo)
        {
            CriarDiretorioSeNaoExistir(nomeArquivo);
            XmlSerializer serializer = new XmlSerializer(typeof(ConfiguracaoOrdenacao));
            TextWriter textWriter = new StreamWriter(nomeArquivo, false, Encoding.UTF8);
            serializer.Serialize(textWriter, configuracao);
            textWriter.Close();
        }

        public static ConfiguracaoOrdenacao DeserializarConfiguracao(string nomeArquivo)
        {
            if (!File.Exists(nomeArquivo))
                return null;

            XmlSerializer deserializer = new XmlSerializer(typeof(ConfiguracaoOrdenacao));
            TextReader textReader = new StreamReader(nomeArquivo, Encoding.Default);
            ConfiguracaoOrdenacao configuracao = (ConfiguracaoOrdenacao)deserializer.Deserialize(textReader);
            textReader.Close();
            return configuracao;
        }
    }
}
