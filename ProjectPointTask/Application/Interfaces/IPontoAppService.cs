using ProjectPointTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPointTask.Application.interfaces
{
    interface IPontoAppService : IDisposable
    {
        PontoViewModel Criar(PontoViewModel pontoViewModel);

        PontoViewModel Atualizar(PontoViewModel pontoViewModel);

        PontoViewModel Deletar(PontoViewModel pontoViewModel);

        PontoViewModel TrazerPorId(Guid Id);

        IEnumerable<PontoViewModel> TrazerTodosAtivos();
    }
}
