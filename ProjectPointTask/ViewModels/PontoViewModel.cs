using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectPointTask.ViewModels
{
    public class PontoViewModel
    {
        public PontoViewModel()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        public DateTime? Chegada { get; set; }

        public DateTime? Saida { get; set; }

        public TimeSpan? AlmocoHoraIni { get; set; }

        public TimeSpan? AlmocoHoraFim { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }

        public virtual UsuarioViewModel Companhia { get; set; }

        public string Id_Usuario { get; set; } = "";

        public string Id_Companhia { get; set; } = "";
    }
}