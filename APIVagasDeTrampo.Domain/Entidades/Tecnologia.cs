using System.Collections.Generic;

namespace APIVagasDeTrampo.Domain.Entidades
{
    public class Tecnologia
    {
        public int TecnologiaId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<CandidatoTecnologia> Candidatos { get; set; }
        public virtual ICollection<VagaTecnologia> TecnologiaVagas { get; set; }

        public Tecnologia()
        {
            Candidatos = new List<CandidatoTecnologia>();
            TecnologiaVagas = new List<VagaTecnologia>();
        }
    }
}
