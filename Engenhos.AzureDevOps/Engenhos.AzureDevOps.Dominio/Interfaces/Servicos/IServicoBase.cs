using System;
using System.Collections.Generic;
using System.Text;

namespace Engenhos.AzureDevOps.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntidade> where TEntidade : class
    {
        void Adicionar(TEntidade obj);
        TEntidade ObterPorId(int id);
        IEnumerable<TEntidade> ObterTodos();
        void Atualizar(TEntidade obj);
        void Remover(TEntidade obj);
    }
}
