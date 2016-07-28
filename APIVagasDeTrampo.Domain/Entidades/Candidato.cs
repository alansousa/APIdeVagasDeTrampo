using System.Collections.Generic;

namespace APIVagasDeTrampo.Domain.Entidades
{
    public class Candidato
    {
        public int CandidatoId { get; set; }
        public string Nome { get; set; }
        public int VagaId { get; set; }

        public virtual Vaga Vaga { get; set; }
        public virtual ICollection<CandidatoTecnologia> Tecnologias { get; set; }

        public Candidato()
        {
            Tecnologias = new List<CandidatoTecnologia>();
        }
    }
}
