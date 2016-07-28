using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.ObjetosDeValor;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace APIVagasDeTrampo.Infra.Data.Context
{
    public class Context : DbContext, IDbContext
    {
        public Context() : base("banco")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        static Context()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());

        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<int>()
                .Where(p => p.Name.EndsWith("Id"))
                .Configure(p => p.IsKey()
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));

            modelBuilder.Properties<string>()
                .Configure(b => b.HasColumnType("varchar").HasMaxLength(255).IsRequired());

            modelBuilder.Properties<DateTime>()
                .Configure(b => b.HasColumnType("datetime"));

            modelBuilder.Ignore<CandidatoPosicaoRanking>();

            modelBuilder.Configurations.AddFromAssembly(typeof(Context).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
