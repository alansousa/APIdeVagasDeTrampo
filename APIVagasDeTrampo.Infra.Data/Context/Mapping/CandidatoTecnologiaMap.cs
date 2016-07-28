using APIVagasDeTrampo.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APIVagasDeTrampo.Infra.Data.Context.Mapping
{
    public class CandidatoTecnologiaMap : EntityTypeConfiguration<CandidatoTecnologia>
    {
        public CandidatoTecnologiaMap()
        {
            HasKey(x => new { x.TecnologiaId, x.CandidatoId });

            Property(x => x.TecnologiaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CandidatoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(a => a.Candidato)
                .WithMany(b => b.Tecnologias)
                .HasForeignKey(c => c.CandidatoId)
                .WillCascadeOnDelete(true);

            HasRequired(a => a.Tecnologia)
                .WithMany(b => b.Candidatos)
                .HasForeignKey(c => c.TecnologiaId)
                .WillCascadeOnDelete(true);
        }
    }
}
