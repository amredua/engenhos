using Engenhos.AzureDevOps.Dominio.Interfaces.Repositorios;
using Engenhos.AzureDevOps.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engenhos.AzureDevOps.Dominio.Servicos
{
    public class ServicoBase<TEntidade> : IServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IRepositorioBase<TEntidade> repositorio;

        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Adicionar(TEntidade obj)
        {
            this.repositorio.Adicionar(obj);
        }

        public void Atualizar(TEntidade obj)
        {
            this.repositorio.Atualizar(obj);
        }

        public TEntidade ObterPorId(int id)
        {
            return this.repositorio.ObterPorID(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return this.repositorio.ObterTodos();
        }

        public void Remover(TEntidade obj)
        {
            repositorio.Remover(obj);
        }
    }
}
