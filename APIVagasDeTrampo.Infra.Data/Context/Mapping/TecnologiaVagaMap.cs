using APIVagasDeTrampo.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APIVagasDeTrampo.Infra.Data.Context.Mapping
{
    public class TecnologiaVagaMap : EntityTypeConfiguration<VagaTecnologia>
    {
        public TecnologiaVagaMap()
        {
            HasKey(x => new { x.TecnologiaId, x.VagaId });

            Property(x => x.TecnologiaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.VagaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(a => a.Vaga)
                .WithMany(b => b.VagaTecnologias)
                .HasForeignKey(c => c.VagaId)
                .WillCascadeOnDelete(true);

            HasRequired(a => a.Tecnologia)
                .WithMany(b => b.TecnologiaVagas)
                .HasForeignKey(c => c.TecnologiaId)
                .WillCascadeOnDelete(true);
        }
    }
}
