using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjectPointTask.Models.EntityConfigs;

namespace ProjectPointTask.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public bool ECompanhia { get; set; }

        public string Id_Companhia { get; set; }

        public virtual Usuario Companhia { get; set; }

        public virtual ICollection<Ponto> PontosUsuario { get; set; }

        public virtual ICollection<Ponto> PontosCompanhia { get; set; }

        public virtual ICollection<Tarefa> TarefasUsuario { get; set; }

        public virtual ICollection<Tarefa> TarefasCompanhia { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<Ponto> Pontos { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<IdentityUser>().ToTable("usuario");
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<IdentityUserRole>().ToTable("usuario_regras");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("logins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("claims");
            modelBuilder.Entity<IdentityRole>().ToTable("regras");

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new PontoConfig());
            modelBuilder.Configurations.Add(new TarefaConfig());

            base.OnModelCreating(modelBuilder);
        }


    }
}