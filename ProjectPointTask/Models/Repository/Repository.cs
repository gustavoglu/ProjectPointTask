using ProjectPointTask.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ProjectPointTask.Models
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {

        protected readonly ApplicationDbContext Db;
        protected DbSet<T> DbSet;
        protected string userName;
        protected string id_usuario;
        protected string id_companhia;
        protected Usuario user;

        public Repository()
        {
            Db = new ApplicationDbContext();
            DbSet = Db.Set<T>();
            userName = HttpContext.Current.User.Identity.Name;
            user = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == userName);
            id_usuario = user.Id;
            id_companhia = user.Id_Companhia;

        }

        public virtual T Atualizar(T obj)
        {

            var entry = Db.Entry(obj);
            entry.State = EntityState.Modified;
            var objAtualizado = DbSet.Add(obj);

            Save();

            return objAtualizado;

        }

        public virtual T Criar(T obj)
        {
            var objCriado = DbSet.Add(obj);

            Save();

            return objCriado;

        }

        public virtual T Deletar(T obj)
        {
            obj.Ativo = false;
            obj.DeletadoEm = DateTime.Now;
            obj.Deletado = true;
            obj.DeletadoPor = HttpContext.Current.User.Identity.Name;

            var entry = Db.Entry(obj);
            entry.State = EntityState.Modified;

            var objDeletado = DbSet.Add(obj);
            return objDeletado;
        }

        public virtual T TrazerPorId(Guid Id)
        {
            if (user.ECompanhia)
            {
                return (from objetos in DbSet.Where(obj => obj.Id == Id)
                        join usuarios in Db.Set<Usuario>().Where(u => u.Id_Companhia == id_usuario)
                        on objetos.CriadoPor equals usuarios.UserName
                        select objetos)
                        .SingleOrDefault();


            }
            else
            {
                return DbSet.SingleOrDefault(obj => obj.Id == Id && obj.CriadoPor == userName);
            }

        }

        public virtual IEnumerable<T> TrazerTodos()
        {
            if (user.ECompanhia)
            {
                return from objetos in DbSet
                       join usuario in Db.Set<Usuario>().Where(u => u.Id_Companhia == id_usuario)
                       on objetos.CriadoPor equals usuario.UserName
                       select objetos;
            }
            else
            {
                return DbSet.Where(obj => obj.CriadoPor == userName);
            }

        }

        public virtual IEnumerable<T> TrazerTodosAtivos()
        {
            if (user.ECompanhia)
            {
                return from objetos in DbSet.Where(obj => obj.Ativo == true)
                       join usuarios in Db.Set<Usuario>().Where(u => u.Id_Companhia == id_usuario)
                       on objetos.CriadoPor equals usuarios.UserName
                       select objetos;
            }
            else
            {
                return DbSet.Where(obj => obj.Ativo == true && obj.CriadoPor == userName);
            }
        }

        public virtual IEnumerable<T> TrazerTodosDeletados()
        {
            if (user.ECompanhia)
            {
                return from objetos in DbSet.Where(obj => obj.Deletado == true)
                       join usuarios in Db.Set<Usuario>().Where(u => u.Id_Companhia == id_usuario)
                       on objetos.CriadoPor equals usuarios.UserName
                       select objetos;
            }
            else
            {
                return DbSet.Where(obj => obj.Deletado == true && obj.CriadoPor == userName);
            }
        }

        public virtual IEnumerable<T> TrazerTodosInativos()
        {
            if (user.ECompanhia)
            {
                return from objetos in DbSet.Where(obj => obj.Ativo == true)
                       join usuarios in Db.Set<Usuario>().Where(u => u.Id_Companhia == id_usuario)
                       on objetos.CriadoPor equals usuarios.UserName
                       select objetos;
            }
            else
            {
                return DbSet.Where(obj => obj.Ativo == false && obj.CriadoPor == userName);
            }
        }

        public virtual int Save()
        {
           return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}