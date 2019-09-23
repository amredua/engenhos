using Engenhos.AzureDevOps.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engenhos.AzureDevOps.Infraestrutura.Repositorios
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class
    {
        protected DbContext Db;

        public RepositorioBase(DbContext Db)
        {
            this.Db = Db;
        }

        public void Adicionar(TEntidade obj)
        {
            Db.Set<TEntidade>().Add(obj);
            Db.SaveChanges();
            
        }

        public void Atualizar(TEntidade obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
           
        }

        public TEntidade ObterPorID(int id)
        {
            return Db.Set<TEntidade>().Find(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return Db.Set<TEntidade>().ToList();
        }

        public void Remover(TEntidade obj)
        {
            Db.Set<TEntidade>().Remove(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
