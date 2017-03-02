using AutoMapper;
using ProjectPointTask.Models;
using ProjectPointTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPointTask.AutoMapper
{
    public class DomainToVieModelProfile : Profile
    {
        public DomainToVieModelProfile()
        {
            CreateMap<Ponto, PontoViewModel>().ReverseMap();
            CreateMap<Tarefa, TarefaViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}