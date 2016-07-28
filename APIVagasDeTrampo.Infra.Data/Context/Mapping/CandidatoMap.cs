using APIVagasDeTrampo.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APIVagasDeTrampo.Infra.Data.Context.Mapping
{
    public class CandidatoMap : EntityTypeConfiguration<Candidato>
    {
        public CandidatoMap()
        {
            HasKey(x => x.CandidatoId);
            Property(x => x.CandidatoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.VagaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            HasRequired(a => a.Vaga)
                .WithMany(b => b.Candidatos)
                .HasForeignKey(c => c.VagaId);
        }
    }
}
