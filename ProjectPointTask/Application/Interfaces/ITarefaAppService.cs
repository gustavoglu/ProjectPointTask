using ProjectPointTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPointTask.Application.interfaces
{
    interface ITarefaAppService : IDisposable
    {
        TarefaViewModel Criar(TarefaViewModel tarefaViewModel);

        TarefaViewModel Atualizar(TarefaViewModel tarefaViewModel);

        TarefaViewModel Deletar(TarefaViewModel tarefaViewModel);

        TarefaViewModel TrazerPorId(Guid Id);

        IEnumerable<TarefaViewModel> TrazerTodosAtivos();
    }
}
