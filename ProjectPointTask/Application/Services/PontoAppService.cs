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
    public class PontoAppService : IPontoAppService
    {
        private readonly IPontoRepository _pontoRepository;

        public PontoAppService()
        {
            _pontoRepository = new PontoRepository();
        }

        public PontoViewModel Atualizar(PontoViewModel pontoViewModel)
        {
            var ponto = Mapper.Map<Ponto>(pontoViewModel);
            return Mapper.Map<PontoViewModel>(_pontoRepository.Atualizar(ponto));
        }

        public PontoViewModel Criar(PontoViewModel pontoViewModel)
        {
            var ponto = Mapper.Map<Ponto>(pontoViewModel);
            return Mapper.Map<PontoViewModel>(_pontoRepository.Criar(ponto));
        }

        public PontoViewModel Deletar(PontoViewModel pontoViewModel)
        {
            var ponto = Mapper.Map<Ponto>(pontoViewModel);
            return Mapper.Map<PontoViewModel>(_pontoRepository.Deletar(ponto));
        }

        public void Dispose()
        {
            _pontoRepository.Dispose();
        }

        public PontoViewModel TrazerPorId(Guid Id)
        {
            return Mapper.Map<PontoViewModel>(_pontoRepository.TrazerPorId(Id));
        }

        public IEnumerable<PontoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<PontoViewModel>>(_pontoRepository.TrazerTodosAtivos());
        }
    }
}