using ProjectPointTask.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPointTask.ViewModels;
using ProjectPointTask.Models.Interfaces;
using ProjectPointTask.Models.Repository;
using AutoMapper;
using ProjectPointTask.Models;

namespace ProjectPointTask.Application.Services
{
    public class TarefaAppService : ITarefaAppService
    {

        private readonly ITarefaRepository _tarefaRepository;

        public TarefaAppService()
        {
            _tarefaRepository = new TarefaRepository();
        }
        public TarefaViewModel Atualizar(TarefaViewModel tarefaViewModel)
        {
            var tarefa = Mapper.Map<Tarefa>(tarefaViewModel);
            return Mapper.Map<TarefaViewModel>(_tarefaRepository.Atualizar(tarefa));

        }
        public TarefaViewModel Criar(TarefaViewModel tarefaViewModel)
        {
            var tarefa = Mapper.Map<Tarefa>(tarefaViewModel);
            return Mapper.Map<TarefaViewModel>(_tarefaRepository.Criar(tarefa));
        }

        public TarefaViewModel Deletar(TarefaViewModel tarefaViewModel)
        {
            var tarefa = Mapper.Map<Tarefa>(tarefaViewModel);
            return Mapper.Map<TarefaViewModel>(_tarefaRepository.Deletar(tarefa));
        }

        public void Dispose()
        {
            _tarefaRepository.Dispose();

        }

        public TarefaViewModel TrazerPorId(Guid Id)
        {
            return Mapper.Map<TarefaViewModel>(_tarefaRepository.TrazerPorId(Id));

        }

        public IEnumerable<TarefaViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<TarefaViewModel>>(_tarefaRepository.TrazerTodosAtivos());
        }
    }
}