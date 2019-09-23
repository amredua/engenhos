using Autofac;
using Engenhos.AzureDevOps.Dominio.Interfaces.Repositorios;
using Engenhos.AzureDevOps.Infraestrutura.Contexto;
using Engenhos.AzureDevOps.Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engenhos.AzureDevOps.CrossCutting.Modulo
{
    public class ModuloDomonioRepositorio : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(RepositorioBase<>))
                .As(typeof(IRepositorioBase<>))
                .InstancePerDependency();

            builder
                .RegisterType<EngenhosAzureDevOpsContexto>()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<RepositorioWorkItem>()
                .As<IRepositorioWorkItem>()
                .InstancePerLifetimeScope();

        }
    }
}
