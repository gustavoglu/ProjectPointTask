using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPointTask.Models
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime? CriadoEm { get; set; }

        public DateTime? DeletadoEm { get; set; }

        public string CriadoPor { get; set; } = "";

        public string DeletadoPor { get; set; } = "";

        public bool? Deletado { get; set; }

        public bool? Ativo { get; set; }

    }
}