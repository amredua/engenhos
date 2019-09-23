using Autofac;
using Engenhos.AzureDevOps.CrossCutting.Modulo;

namespace Engenhos.AzureDevOps.CrossCutting
{
    public class IoC
    {
        public IContainer Container { get; private set; }

        /// <summary>
        /// Construtor usado para aplicação console
        /// </summary>
        public IoC()
        {
            var builder = new ContainerBuilder();
            ConfigurarContainer(builder);
            this.Container = builder.Build();
        }

        /// <summary>
        /// Construtor usado para aplicação web
        /// </summary>
        public IoC(ContainerBuilder builder)
        {
            ConfigurarContainer(builder);
        }

        private void ConfigurarContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModuloDomonioRepositorio());
            builder.RegisterModule(new ModuloDominioServico());
            builder.RegisterModule(new ModuloAplicacao());
        }
    }
}
