using Autofac;
using Engenhos.AzureDevOps.Dominio.Interfaces.Servicos;
using Engenhos.AzureDevOps.Dominio.Servicos;

namespace Engenhos.AzureDevOps.CrossCutting.Modulo
{
    public class ModuloDominioServico : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(ServicoBase<>))
                .As(typeof(IServicoBase<>))
                .InstancePerDependency();


            builder
                .RegisterType<ServicoWorkItem>()
                .As<IServicoWorkItem>()
                .InstancePerLifetimeScope();

        }
    }
}
