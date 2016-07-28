using APIVagasDeTrampo.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APIVagasDeTrampo.Infra.Data.Context.Mapping
{
    public class TecnologiaMap: EntityTypeConfiguration<Tecnologia>
    {
        public TecnologiaMap()
        {
            HasKey(x => x.TecnologiaId);
            Property(x => x.TecnologiaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            
        }
    }
}
