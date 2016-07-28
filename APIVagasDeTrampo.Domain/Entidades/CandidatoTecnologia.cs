namespace APIVagasDeTrampo.Domain.Entidades
{
    public class CandidatoTecnologia
    {
        public int CandidatoId { get; set; }
        public int TecnologiaId { get; set; }
        public virtual Candidato Candidato { get; set; }
        public virtual Tecnologia Tecnologia { get; set; }
    }
}
