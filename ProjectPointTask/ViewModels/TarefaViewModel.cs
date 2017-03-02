using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectPointTask.ViewModels
{
    public class TarefaViewModel
    {
        public TarefaViewModel()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        public string Descricao { get; set; } = "";

        public int? Prioridade { get; set; }

        public DateTime? DataFinalizacao { get; set; }

        public DateTime? PreData { get; set; }

        public bool? Finalizada { get; set; }

        public bool? Padrao { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }

        public virtual UsuarioViewModel Companhia{ get; set; }

        public string Id_Usuario { get; set; } = "";

        public string Id_Companhia { get; set; } = "";


    }
}