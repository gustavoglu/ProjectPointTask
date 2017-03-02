using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjectPointTask.Models.EntityConfigs
{
    public class PontoConfig : EntityTypeConfiguration<Ponto>
    {
        public PontoConfig()
        {
            ToTable("ponto");

            HasKey(p => p.Id);

            HasRequired(p => p.Usuario)
                .WithMany(u => u.PontosUsuario)
                .HasForeignKey(p => p.Id_Usuario);

            HasRequired(p => p.Companhia)
                .WithMany(u => u.PontosCompanhia)
                .HasForeignKey(p => p.Id_Companhia);

        }
    }
}