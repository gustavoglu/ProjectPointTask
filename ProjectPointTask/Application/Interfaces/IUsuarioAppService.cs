using ProjectPointTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPointTask.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        IEnumerable<UsuarioViewModel> Companhias();

        //UsuarioViewModel 
    }
}