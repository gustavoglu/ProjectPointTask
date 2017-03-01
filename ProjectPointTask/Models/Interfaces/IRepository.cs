using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPointTask.Models.Interfaces
{
    public interface IRepository<T>
    {
        T Criar(T obj);

        T Atualizar(T obj);

        T Deletar(T obj);

        T TrazerPorId(Guid Id);

        IEnumerable<T> TrazerTodos();

        IEnumerable<T> TrazerTodosAtivos();

        IEnumerable<T> TrazerTodosDeletados();

        IEnumerable<T> TrazerTodosInativos();

    }
}