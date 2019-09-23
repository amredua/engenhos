using System;
using System.Collections.Generic;
using System.Text;

namespace Engenhos.AzureDevOps.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidade> where TEntidade : class
    {
        void Adicionar(TEntidade obj);
        TEntidade ObterPorID(int id);
        IEnumerable<TEntidade> ObterTodos();
        void Atualizar(TEntidade obj);
        void Remover(TEntidade obj);
        void Dispose();
    }
}
