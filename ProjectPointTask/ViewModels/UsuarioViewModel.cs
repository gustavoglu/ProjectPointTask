using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectPointTask.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public string Id { get; set; }

        public string Nome { get; set; } = "";

        public string Sobrenome { get; set; } = "";

        public bool? ECompanhia { get; set; }

        public string Id_Companhia { get; set; } = "";

        public UsuarioViewModel Companhia { get; set; }

        public virtual ICollection<PontoViewModel> PontosUsuario { get; set; }

        public virtual ICollection<PontoViewModel> PontosCompanhia { get; set; }

        public virtual ICollection<TarefaViewModel> TarefasUsuario { get; set; }

        public virtual ICollection<TarefaViewModel> TarefasCompanhia { get; set; }

    }
}