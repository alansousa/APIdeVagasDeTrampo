using APIVagasDeTrampo.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APIVagasDeTrampo.Infra.Data.Context.Mapping
{
    public class VagaMap: EntityTypeConfiguration<Vaga>
    {
        public VagaMap()
        {
            HasKey(x => x.VagaId);
            Property(x => x.VagaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
