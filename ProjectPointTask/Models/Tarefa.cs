﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPointTask.Models
{
    public class Tarefa : EntityBase
    {

        public string Descricao { get; set; } = "";

        public int? Prioridade { get; set; }

        public DateTime? DataFinalizacao { get; set; }

        public bool? Finalizada { get; set; }

        public DateTime? PreData { get; set; }

        public bool? Padrao { get; set; }

        public string Id_Usuario { get; set; } = "";

        public string Id_Companhia { get; set; } = "";

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Companhia { get; set; }

    }
}