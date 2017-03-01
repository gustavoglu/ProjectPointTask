using ProjectPointTask.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectPointTask.Models
{
    public class Repository<T> : IRepository<T> where T : EntityBase 
    {

        private readonly ApplicationDbContext Db;
        public DbSet<T> DbSet;

        public Repository()
        {
            Db = new ApplicationDbContext();
            DbSet = Db.Set<T>();
        }

        public T Atualizar(T obj)
        {
            throw new NotImplementedException();
        }

        public T Criar(T obj)
        {
            throw new NotImplementedException();
        }

        public T Deletar(T obj)
        {
            throw new NotImplementedException();
        }

        public T TrazerPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> TrazerTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> TrazerTodosAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> TrazerTodosDeletados()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> TrazerTodosInativos()
        {
            throw new NotImplementedException();
        }
    }
}