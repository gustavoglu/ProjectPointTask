using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjectPointTask.Models.EntityConfigs
{
    public class TarefaConfig : EntityTypeConfiguration<Tarefa>
    {
        public TarefaConfig()
        {
            ToTable("tarefa");

            HasKey(t => t.Id);

            HasRequired(t => t.Usuario)
                .WithMany(c => c.TarefasUsuario)
                .HasForeignKey(t => t.Id_Usuario);

            HasRequired(t => t.Companhia)
                .WithMany(c => c.TarefasCompanhia)
                .HasForeignKey(t => t.Id_Companhia);

        }
    }
}