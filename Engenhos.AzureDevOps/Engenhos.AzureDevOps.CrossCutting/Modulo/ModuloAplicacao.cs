using Autofac;
using Engenhos.AzureDevOps.Aplicacao.Ordenacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engenhos.AzureDevOps.CrossCutting.Modulo
{
    class ModuloAplicacao : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
               .RegisterType<ServicoOrdenacao>()
               .As<IServicoOrdenacao>()
               .InstancePerLifetimeScope();

            builder
                .RegisterType<OrdenacaoWorkItems>()
                .As<IOrdenacaoWorkItems>()
                .InstancePerLifetimeScope();

        }
    }
}
