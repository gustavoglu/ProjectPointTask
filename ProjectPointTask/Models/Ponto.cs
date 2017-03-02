using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPointTask.Models
{
    public class Ponto : EntityBase
    {

        public DateTime? Chegada { get; set; }

        public DateTime? Saida { get; set; }

        public TimeSpan? AlmocoHoraIni { get; set; }

        public TimeSpan? AlmocoHoraFim { get; set; }

        public string Id_Usuario { get; set; } = "";

        public string Id_Companhia { get; set; } = "";

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Companhia { get; set; }

    }
}